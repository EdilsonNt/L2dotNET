using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TradeDone
    {
        private const byte Opcode = 0x1c;

        internal static Packet ToPacket(bool done = true)
        {
            Packet p = new Packet(Opcode);
            p.WriteByte(done ? (byte)1 : (byte)0);
            return p;
        }
    }
}