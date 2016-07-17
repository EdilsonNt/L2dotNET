using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;
using L2dotNET.Utility;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TutorialShowHtml
    {
        private const byte Opcode = 0xa0;

        internal static Packet ToPacket(string html)
        {
            Packet p = new Packet(Opcode);
            p.WriteString(html);
            return p;
        }
    }
}