using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharFlyToLocation
    {
        private const byte Opcode = 0xC5;

        internal static Packet ToPacket(L2Object obj, FlyType type)
        {
            Packet p = new Packet(Opcode);

            p.WriteInt(obj.ObjId);
            p.WriteInt(obj.DestX, obj.DestY, obj.DestZ);
            p.WriteInt(obj.X, obj.Y, obj.Z);
            p.WriteInt((int)type);
            return p;
        }
    }
}