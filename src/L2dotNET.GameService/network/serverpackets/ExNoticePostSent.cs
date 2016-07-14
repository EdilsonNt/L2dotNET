using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExNoticePostSent
    {
        private const short Opcode = 0xb4;

        internal static Packet ToPacket(int anim)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(anim);
            return p;
        }
    }
}