using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ObservationMode
    {
        private const byte Opcode = 0xdf;

        internal static Packet ToPacket(int x, int y, int z)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(x);
            p.WriteInt(y);
            p.WriteInt(z);
            p.WriteInt(0x00);
            p.WriteInt(0xc0);
            p.WriteInt(0x00);
            return p;
        }
    }
}