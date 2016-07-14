namespace L2dotNET.GameService.Network.Serverpackets
{
    class SendTradeRequest
    {
        private readonly int _sId;

        public SendTradeRequest(int sId)
        {
            _sId = sId;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x5e);
            p.WriteInt(_sId);
        }
    }
}