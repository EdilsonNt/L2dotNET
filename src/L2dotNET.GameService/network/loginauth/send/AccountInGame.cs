namespace L2dotNET.GameService.Network.LoginAuth.Send
{
    class AccountInGame
    {
        private readonly string _account;
        private readonly bool _status;

        public AccountInGame(string account, bool status)
        {
            _account = account;
            _status = status;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x03);
            p.WriteString(_account.ToLower());
            p.WriteInt(_status ? (byte)1 : (byte)0);
        }
    }
}