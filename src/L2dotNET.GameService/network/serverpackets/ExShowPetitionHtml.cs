using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExShowPetitionHtml
    {
        private const short Opcode = 0xB1;

        internal static Packet ToPacket(string text)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);

            p.WriteInt(0);
            p.WriteInt(0);
            p.WriteString(text);
            return p;
        }
    }
}