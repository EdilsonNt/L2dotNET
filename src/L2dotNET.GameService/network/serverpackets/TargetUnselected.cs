using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TargetUnselected
    {
        private const byte Opcode = 0x2a;

        internal static Packet ToPacket(L2Object obj)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(obj.ObjId);
            p.WriteInt(obj.X);
            p.WriteInt(obj.Y);
            p.WriteInt(obj.Z);
            return p;
        }
    }
}