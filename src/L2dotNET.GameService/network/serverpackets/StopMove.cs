using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class StopMove
    {
        private const byte Opcode = 0x47;

        internal static Packet ToPacket(L2Character cha)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(cha.ObjId);
            p.WriteInt(cha.X);
            p.WriteInt(cha.Y);
            p.WriteInt(cha.Z);
            p.WriteInt(cha.Heading);
            return p;
        }
    }
}