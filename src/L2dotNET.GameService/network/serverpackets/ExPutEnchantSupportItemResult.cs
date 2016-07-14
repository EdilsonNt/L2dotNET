namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExPutEnchantSupportItemResult
    {
        private readonly int _result;

        public ExPutEnchantSupportItemResult(int result = 0)
        {
            _result = result;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x82);
            p.WriteInt(_result);
        }
    }
}