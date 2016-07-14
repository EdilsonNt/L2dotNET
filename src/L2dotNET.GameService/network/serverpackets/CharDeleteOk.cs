using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharDeleteOk
    {
        private const byte Opcode = 0x23;

        internal static Packet ToPacket()
        {
            return new Packet(Opcode);
        }
    }
}