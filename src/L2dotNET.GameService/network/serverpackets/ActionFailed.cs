using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ActionFailed
    {
        private const byte Opcode = 0x25;

        internal static Packet ToPacket()
        {
            return new Packet(Opcode);
        }
    }
}