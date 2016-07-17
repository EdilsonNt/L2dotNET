using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SunSet
    {
        private const byte Opcode = 0x1d;
        internal static Packet ToPacket()
        {
            return new Packet(Opcode);
        }
    }
}