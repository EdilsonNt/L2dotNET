using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Tables;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExBuySellListBuy
    {
        private readonly NdShopList _shop;
        private readonly long _adena;
        private readonly double _mod;
        private readonly double _tax;
        private readonly int _shopId;

        public ExBuySellListBuy(L2Player player, NdShopList shop, double mod, double tax, int shopId)
        {
            _shop = shop;
            _adena = player.GetAdena();
            _mod = mod;
            _tax = tax;
            _shopId = shopId;
        }

        public ExBuySellListBuy(long adena)
        {
            _adena = adena;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0xB7);
            p.WriteInt(0);
            p.WriteInt(_adena);
            p.WriteInt(_shopId);

            if (_shop == null)
            {
                p.WriteShort(0);
                return;
            }

            p.WriteShort(_shop.Items.Count);
            foreach (NDShopItem si in _shop.Items)
            {
                p.WriteInt(0); //objectId
                p.WriteInt(si.Item.ItemId);
                p.WriteInt(0);
                p.WriteInt(si.Count < 0 ? 0 : si.Count);
                p.WriteShort(si.Item.Type2);
                p.WriteShort(0);
                p.WriteShort(0);
                p.WriteInt(si.Item.BodyPart);

                p.WriteShort(0);
                p.WriteShort(0);
                p.WriteInt(0);
                p.WriteInt(0);
                p.WriteInt(-9999);

                // Enchant Effects
                p.WriteShort(0x00);
                p.WriteShort(0x00);
                p.WriteShort(0x00);

                p.WriteInt((long)(si.Item.ReferencePrice * _mod * _tax));
            }
        }
    }
}