using L2dotNET.GameService.World;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TargetSelected
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;
        private readonly int _objectId;
        private readonly int _targetObjId;

        public TargetSelected(int selecterId, L2Object target)
        {
            _objectId = selecterId;
            _targetObjId = target.ObjId;
            _x = target.X;
            _y = target.Y;
            _z = target.Z;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x29);
            p.WriteInt(_objectId);
            p.WriteInt(_targetObjId);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
        }
    }
}