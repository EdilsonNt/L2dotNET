using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TutorialCloseHtml
    {
        private const byte Opcode = 0xa3;
        internal static Packet ToPacket()
        {
            return new Packet(Opcode);
        }
    }
}