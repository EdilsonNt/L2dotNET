using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PartySmallWindowDeleteAll
    {
        private const byte Opcode = 0x50;

        internal static Packet ToPacket()
        {
            return new Packet(Opcode);
        }
    }
}