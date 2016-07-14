using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExChangeNicknameNColor
    {
        private const short Opcode = 0x83;
        internal static Packet ToPacket()
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            return p;
        }
    }
}