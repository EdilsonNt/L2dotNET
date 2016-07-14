using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharMoveToLocation
    {
        private const byte Opcode = 0x01;

        internal static Packet ToPacket(L2Object obj)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(obj.ObjId);
            p.WriteInt(obj.DestX, obj.DestY, obj.DestZ);

            p.WriteInt(obj.X, obj.Y, obj.Z);
            return p;
        }
    }
}