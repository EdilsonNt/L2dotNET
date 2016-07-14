using L2dotNET.GameService.World;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharMoveToLocation
    {
        private readonly L2Object _obj;

        public CharMoveToLocation(L2Object obj)
        {
            _obj = obj;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x01);

            p.WriteInt(_obj.ObjId);

            p.WriteInt(_obj.DestX);
            p.WriteInt(_obj.DestY);
            p.WriteInt(_obj.DestZ);

            p.WriteInt(_obj.X);
            p.WriteInt(_obj.Y);
            p.WriteInt(_obj.Z);
        }
    }
}