namespace L2dotNET.GameService.Network.Serverpackets
{
    class TeleportToLocation
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;
        private readonly int _id;
        private int _heading;

        public TeleportToLocation(int id, int x, int y, int z, int h)
        {
            _x = x;
            _y = y;
            _z = z;
            _id = id;
            _heading = h;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x28);
            p.WriteInt(_id);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
        }
    }
}