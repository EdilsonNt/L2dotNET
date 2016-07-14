using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class FriendList
    {
        private const byte Opcode = 0xfa;

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            return p;
        }
    }
}