using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class AskJoinParty
    {
        private const byte Opcode = 0x39;

        internal static Packet ToPacket(string asker, int itemDistribution)
        {
            Packet p = new Packet(Opcode);
            p.WriteString(asker);
            p.WriteInt(itemDistribution);
            return p;
        }
    }
}