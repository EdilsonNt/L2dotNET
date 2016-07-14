namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExAutoSoulShot
    {
        private readonly int _itemId;
        private readonly int _type;

        public ExAutoSoulShot(int itemId, int type)
        {
            _itemId = itemId;
            _type = type;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0x12);
            p.WriteInt(_itemId);
            p.WriteInt(_type);
        }
    }
}