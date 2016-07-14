using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Tables;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ShopPreviewList
    {
        private readonly int _adena;
        private readonly NdShopList _shop;
        private readonly int _shopId;

        public ShopPreviewList(L2Player player, NdShopList shop, int shopId)
        {
            _adena = player.GetAdena();
            _shop = shop;
            _shopId = shopId;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xef);
            p.WriteInt(0xc0); // ?
            p.WriteInt(0x13); // ?
            p.WriteInt(0x00); // ?
            p.WriteInt(0x00); // ?
            p.WriteInt(_adena); // current money
            p.WriteInt(_shopId);

            foreach (NDShopItem si in _shop.Items)
            {
                p.WriteInt(si.Item.ItemId);
                p.WriteShort(si.Item.Type2);
                p.WriteShort(si.Item.BodyPart);
                p.WriteInt(10);
            }
        }
    }
}