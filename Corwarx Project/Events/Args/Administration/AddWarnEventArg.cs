namespace Corwarx_Project.Events.Args.Administration {
    public class AddWarnEventArg {
        public AddWarnEventArg(string steamID, string message, string nickname, int player_id) {
            SteamID = steamID;
            Message = message;
            Nickname = nickname;
            PlayerID = player_id;
        }

        public string SteamID;
        public string Message;
        public string Nickname;
        public int PlayerID;
    }
}
