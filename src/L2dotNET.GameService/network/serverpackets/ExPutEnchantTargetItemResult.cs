namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExPutEnchantTargetItemResult
    {
        private readonly int _result;

        public ExPutEnchantTargetItemResult(int result = 0)
        {
            _result = result;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x81);
            p.WriteInt(_result);
        }
    }
}