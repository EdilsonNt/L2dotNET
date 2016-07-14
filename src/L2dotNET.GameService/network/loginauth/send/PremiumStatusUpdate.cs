namespace L2dotNET.GameService.Network.LoginAuth.Send
{
    class PremiumStatusUpdate
    {
        private readonly string _account;
        private readonly byte _status;
        private readonly long _points;

        public PremiumStatusUpdate(string account, byte status, long points)
        {
            _account = account;
            _status = status;
            _points = points;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xA4);
            p.WriteString(_account.ToLower());
            p.WriteInt(_status);
            p.WriteInt(_points);
        }
    }
}