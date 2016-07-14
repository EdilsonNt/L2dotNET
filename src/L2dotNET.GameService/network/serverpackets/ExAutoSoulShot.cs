using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExAutoSoulShot
    {
        private const short Opcode = 0x12;

        internal static Packet ToPacket(int itemId, int type)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(itemId);
            p.WriteInt(type);
            return p;
        }
    }
}