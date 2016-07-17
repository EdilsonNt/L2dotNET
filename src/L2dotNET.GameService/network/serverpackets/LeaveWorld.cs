using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class LeaveWorld
    {
        private const byte Opcode = 0x7e;

        internal static Packet ToPacket()
        {
            return new Packet(Opcode);
        }
    }
}