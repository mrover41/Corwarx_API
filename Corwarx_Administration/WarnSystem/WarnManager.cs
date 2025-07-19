using Corwarx_Project.Events.Handles;
using Corwarx_Project.Events.Args.Administration;
using System.IO;
using System.Collections.Generic;
using Exiled.API.Features;
using Corwarx_Administration.Dat;
using System;


namespace Corwarx_Administration.WarnSystem {
    internal static class WarnManager {
        public static void AddWarn(string steamID, string message, string nickname, int player_id, out string response) {
            response = "Error :(";
            if (!Administration.OnAddingWarnEvent(new AddingWarnEventArg(steamID, message, nickname, player_id)).IsAllowed) return;

            string dataPath = Path.Combine(Path.GetDirectoryName(Loader.Instance.ConfigPath), "Corwarx_WarnData", $"{steamID}.corwarxAPIdata");
            if (!Directory.Exists(Path.GetDirectoryName(dataPath))) {
                Directory.CreateDirectory(Path.GetDirectoryName(dataPath));
            }

            List<WarnData> warns = new List<WarnData>();

            if (File.Exists(dataPath))
                warns = ParseFile(dataPath);

            warns.Add(new WarnData {
                ID = steamID.ToString(),
                Nickname = nickname,
                Message = message
            });

            DateTime now = DateTime.Now;

            List<string> lines = new List<string>();
            foreach (WarnData warn in warns)
                lines.Add($"{warn.ID}!{warn.Nickname}?{warn.Message}[Time: {now.ToString("HH:mm dd.MM.yyyy")}]");

            File.WriteAllLines(dataPath, lines);

            response = $"Warn added. Total warns: {warns.Count}/{Loader.Instance.Config.WarnLimit}, SteamID: {steamID}";


            Administration.OnAddWarnEvent(new AddWarnEventArg(steamID, message, nickname, player_id));
        }

        public static void ClearWarns(string steamID) {
            string dataPath = Path.Combine(Path.GetDirectoryName(Loader.Instance.ConfigPath), "Corwarx_WarnData");
            if (Directory.Exists(dataPath)) {
                File.Delete(Path.Combine(dataPath, $"{steamID}.corwarxAPIdata"));
            }
        }

            public static List<WarnData> GetWarns(string steamID) {
                string dataPath = Path.Combine(Path.GetDirectoryName(Loader.Instance.ConfigPath), "Corwarx_WarnData", $"{steamID}.corwarxAPIdata");
                if (!File.Exists(dataPath)) return new List<WarnData>();

                return ParseFile(dataPath);
            }

        private static List<WarnData> ParseFile(string filePath) {
            var list = new List<WarnData>();

            foreach (var line in File.ReadLines(filePath)) {
                int exclIndex = line.IndexOf('!');
                int questIndex = line.IndexOf('?');

                if (exclIndex == -1 || questIndex == -1 || exclIndex > questIndex) {
                    Log.Error("формат файла сломан");
                    continue;
                }

                string id = line.Substring(0, exclIndex);
                string nickname = line.Substring(exclIndex + 1, questIndex - exclIndex - 1);
                string message = line.Substring(questIndex + 1);

                list.Add(new WarnData {
                    ID = id,
                    Nickname = nickname,
                    Message = message
                });
            }

            return list;
        }
    }
}
