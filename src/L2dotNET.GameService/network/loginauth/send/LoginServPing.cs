namespace L2dotNET.GameService.Network.LoginAuth.Send
{
    class LoginServPing
    {
        public string Version;
        private readonly int _build;

        public LoginServPing(AuthThread th)
        {
            Version = th.Version;
            _build = th.Build;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xA0);
            p.WriteString(Version);
            p.WriteInt(_build);
        }
    }
}