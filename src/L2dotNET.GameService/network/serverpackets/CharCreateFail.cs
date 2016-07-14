using L2dotNET.GameService.Enums;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharCreateFail
    {
        private const byte Opcode = 0x1a;

        internal static Packet ToPacket(CharCreateFailReason reason)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt((int)reason);
            return p;
        }
    }
}