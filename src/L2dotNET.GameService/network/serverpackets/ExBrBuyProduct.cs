namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExBrBuyProduct
    {
        private readonly int _result;

        public ExBrBuyProduct(int result)
        {
            _result = result;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0xCC);
            p.WriteInt(_result);
        }
    }
}