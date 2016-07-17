using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    public class ShowTownMap
    {
        private const byte Opcode = 0xde;

        internal static Packet ToPacket(string texture, int x, int y)
        {
            Packet p = new Packet(Opcode);
            p.WriteString(texture);
            p.WriteInt(x, y);
            return p;
        }
    }
}