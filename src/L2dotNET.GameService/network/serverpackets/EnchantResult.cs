namespace L2dotNET.GameService.Network.Serverpackets
{
    class EnchantResult
    {
        private readonly EnchantResultVal _result;
        private int _crystal;
        private long _count;

        public EnchantResult(EnchantResultVal result, int crystal = 0, long count = 0)
        {
            _result = result;
            _crystal = crystal;
            _count = count;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x81);
            p.WriteInt((int)_result);
            //p.WriteInt(crystal);
            //p.WriteInt(count);
        }
    }
}