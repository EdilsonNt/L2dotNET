using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeInfo
    {
        private const byte Opcode = 0x83;

        internal static Packet ToPacket(int id, string name, string ally)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(id);
            p.WriteString(name);
            p.WriteString(ally);
            return p;
        }
    }
}