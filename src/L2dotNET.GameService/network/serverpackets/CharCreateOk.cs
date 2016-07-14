using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharCreateOk
    {
        private const byte Opcode = 0x19;

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0x01);
            return p;
        }
    }
}