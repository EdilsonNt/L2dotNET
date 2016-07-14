using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExBrBuyProduct
    {
        private const short Opcode = 0xCC;

        internal static Packet ToPacket(int result)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(result);
            return p;
        }
    }
}