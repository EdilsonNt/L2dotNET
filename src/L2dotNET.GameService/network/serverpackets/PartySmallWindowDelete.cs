using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PartySmallWindowDelete
    {
        private const byte Opcode = 0x51;

        internal static Packet ToPacket(int id, string name)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(id);
            p.WriteString(name);
            return p;
        }
    }
}