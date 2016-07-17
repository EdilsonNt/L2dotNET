using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class Revive
    {
        private const byte Opcode = 0x07;

        internal static Packet ToPacket(int objId)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(objId);
            return p;
        }
    }
}