using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class GetItem
    {
        private const byte Opcode = 0x0d;
        internal static Packet ToPacket(int id, int itemId, int x, int y, int z)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(id);
            p.WriteInt(itemId);
            p.WriteInt(x);
            p.WriteInt(y);
            p.WriteInt(z);
            return p;
        }
    }
}