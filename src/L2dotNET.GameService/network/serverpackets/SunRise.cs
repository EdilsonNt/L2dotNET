using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SunRise
    {
        private const byte Opcode = 0x1c;
        internal static Packet ToPacket()
        {
            return new Packet(Opcode);
        }
    }
}