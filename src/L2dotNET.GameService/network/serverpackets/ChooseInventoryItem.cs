namespace L2dotNET.GameService.Network.Serverpackets
{
    class ChooseInventoryItem
    {
        private readonly int _itemId;

        public ChooseInventoryItem(int itemId)
        {
            _itemId = itemId;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x6f);
            p.WriteInt(_itemId);
        }
    }
}