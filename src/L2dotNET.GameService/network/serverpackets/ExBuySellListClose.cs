using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExBuySellListClose
    {
        private const short Opcode = 0xB7;

        internal static Packet ToPacket()
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(1);
            p.WriteShort(0);
            p.WriteShort(0);
            p.WriteInt(1);
            return p;
        }
    }
}