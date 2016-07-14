using L2dotNET.GameService.World;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class MoveToPawn
    {
        private readonly int _id;
        private readonly int _target;
        private readonly int _dist;
        private int _x;
        private readonly int _tx;
        private int _y;
        private readonly int _ty;
        private int _z;
        private readonly int _tz;

        public MoveToPawn(int id, L2Object target, int dist, int x, int y, int z)
        {
            _id = id;
            _target = target.ObjId;
            _dist = dist;
            _x = x;
            _y = y;
            _z = z;
            _tx = target.X;
            _ty = target.Y;
            _tz = target.Z;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x60);

            p.WriteInt(_id);
            p.WriteInt(_target);
            p.WriteInt(_dist);

            //p.WriteInt(_x);
            //p.WriteInt(_y);
            //p.WriteInt(_z);
            p.WriteInt(_tx);
            p.WriteInt(_ty);
            p.WriteInt(_tz);
        }
    }
}