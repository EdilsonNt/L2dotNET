using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class Calculator
    {
        private const byte Opcode = 0xe2;

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(4393);
            return p;
        }
    }
}