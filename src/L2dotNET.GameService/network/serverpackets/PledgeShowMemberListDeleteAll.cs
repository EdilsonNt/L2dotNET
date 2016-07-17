using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeShowMemberListDeleteAll
    {
        private const byte Opcode = 0x82;
        internal static Packet ToPacket()
        {
            return new Packet(Opcode);
        }
    }
}