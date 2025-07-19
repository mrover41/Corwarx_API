namespace Corwarx_Administration.Dat {
    class WarnData {
        public string ID;
        public string Nickname;
        public string Message;

        public override string ToString() => $"ID: {ID}, Nickname: {Nickname}, Message: {Message}";
    }
}