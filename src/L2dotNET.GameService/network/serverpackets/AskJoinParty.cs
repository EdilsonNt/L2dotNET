using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class AskJoinParty
    {
        private readonly string _asker;
        private readonly int _itemDistribution;

        public AskJoinParty(string asker, int itemDistribution)
        {
            _asker = asker;
            _itemDistribution = itemDistribution;
        }

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0x39);
            p.WriteString(_asker);
            p.WriteInt(_itemDistribution);
        }
    }
}