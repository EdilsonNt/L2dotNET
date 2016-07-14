using L2dotNET.GameService.Enums;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharDeleteFail
    {
        private const byte Opcode = 0x24;

        internal static Packet ToPacket(CharDeleteFailReason reason)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt((int)reason);
            return p;
        }
    }
}