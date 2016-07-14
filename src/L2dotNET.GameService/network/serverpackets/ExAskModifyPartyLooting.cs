using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExAskModifyPartyLooting
    {
        private const short Opcode = 0xBE;

        internal static Packet ToPacket(string leader, byte mode)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteString(leader);
            p.WriteInt(mode);
            return p;
        }
    }
}