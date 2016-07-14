using L2dotNET.GameService.World;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TargetUnselected
    {
        private readonly int _id;
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;

        public TargetUnselected(L2Object obj)
        {
            _id = obj.ObjId;
            _x = obj.X;
            _y = obj.Y;
            _z = obj.Z;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x2a);
            p.WriteInt(_id);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
        }
    }
}