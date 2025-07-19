namespace Corwarx_Project.Events.Args.Administration {
    public class AddingWarnEventArg {
        public AddingWarnEventArg(string steamID, string message, string nickname, int player_id) {
            SteamID = steamID;
            Message = message;
            Nickname = nickname;
            PlayerID = player_id;
            IsAllowed = true;
        }

        public string SteamID { get; }
        public string Message { get; }
        public string Nickname { get; }
        public int PlayerID { get; }
        public bool IsAllowed { get; }
    }
}
