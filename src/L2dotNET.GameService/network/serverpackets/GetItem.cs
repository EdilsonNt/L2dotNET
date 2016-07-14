namespace L2dotNET.GameService.Network.Serverpackets
{
    class GetItem
    {
        private readonly int _id;
        private readonly int _itemId;
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;

        public GetItem(int id, int itemId, int x, int y, int z)
        {
            _id = id;
            _itemId = itemId;
            _x = x;
            _y = y;
            _z = z;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x0d);
            p.WriteInt(_id);
            p.WriteInt(_itemId);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
        }
    }
}