using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ObservationReturn
    {
        private const byte Opcode = 0xe0;

        internal static Packet ToPacket(int x, int y, int z)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(x);
            p.WriteInt(y);
            p.WriteInt(z);
            return p;
        }
    }
}