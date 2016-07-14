using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharFlyToLocation
    {
        private readonly L2Object _obj;
        private readonly int _id;

        public CharFlyToLocation(L2Object obj, FlyType type)
        {
            _obj = obj;
            _id = (int)type;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xC5);

            p.WriteInt(_obj.ObjId);

            p.WriteInt(_obj.DestX);
            p.WriteInt(_obj.DestY);
            p.WriteInt(_obj.DestZ);

            p.WriteInt(_obj.X);
            p.WriteInt(_obj.Y);
            p.WriteInt(_obj.Z);

            p.WriteInt(_id);
        }
    }
}