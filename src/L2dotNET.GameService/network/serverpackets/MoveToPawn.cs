using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class MoveToPawn
    {
        private const byte Opcode = 0x60;

        internal static Packet ToPacket(L2Character cha, L2Object target, int dist)
        {
            Packet p = new Packet(Opcode);

            p.WriteInt(cha.ObjId);
            p.WriteInt(target.ObjId);
            p.WriteInt(dist);
            p.WriteInt(cha.X, cha.Y, cha.Z);
            return p;
        }
    }
}