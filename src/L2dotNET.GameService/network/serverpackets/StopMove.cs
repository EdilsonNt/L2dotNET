using L2dotNET.GameService.World;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class StopMove
    {
        private readonly int _id;
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;
        private readonly int _h;

        public StopMove(L2Character cha)
        {
            _id = cha.ObjId;
            _x = cha.X;
            _y = cha.Y;
            _z = cha.Z;
            _h = cha.Heading;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x47);
            p.WriteInt(_id);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
            p.WriteInt(_h);
        }
    }
}