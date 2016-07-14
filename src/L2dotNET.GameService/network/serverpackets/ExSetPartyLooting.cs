using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExSetPartyLooting
    {
        private const short Opcode = 0xBF;

        internal static Packet ToPacket(short voteId)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            if (voteId == -1)
                return p;
            p.WriteInt(1);
            p.WriteInt(voteId);
            return p;
        }
    }
}