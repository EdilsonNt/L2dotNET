using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ChooseInventoryItem
    {
        private const byte Opcode = 0x6f;

        internal static Packet ToPacket(int itemId)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(itemId);
            return p;
        }
    }
}