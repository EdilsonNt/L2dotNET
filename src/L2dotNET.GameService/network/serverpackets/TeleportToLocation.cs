using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TeleportToLocation
    {
        private const byte Opcode = 0x28;

        internal static Packet ToPacket(L2Object obj, int x, int y, int z)
        {
            Packet p =  new Packet(Opcode);
            p.WriteInt(obj.ObjId);
            p.WriteInt(x);
            p.WriteInt(y);
            p.WriteInt(z);
            return p;
        }
    }
}