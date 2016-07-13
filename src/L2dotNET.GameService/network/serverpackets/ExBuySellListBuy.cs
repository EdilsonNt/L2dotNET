﻿using L2dotNET.GameService.Model.Player;
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

        protected internal override void Write()
        {
            WriteC(0xFE);
            WriteH(0xB7);
            WriteD(0);
            WriteQ(_adena);
            WriteD(_shopId);

            if (_shop == null)
            {
                WriteH(0);
                return;
            }

            WriteH(_shop.Items.Count);
            foreach (NDShopItem si in _shop.Items)
            {
                WriteD(0); //objectId
                WriteD(si.Item.ItemId);
                WriteD(0);
                WriteQ(si.Count < 0 ? 0 : si.Count);
                WriteH(si.Item.Type2);
                WriteH(0);
                WriteH(0);
                WriteD(si.Item.BodyPart);

                WriteH(0);
                WriteH(0);
                WriteD(0);
                WriteD(0);
                WriteD(-9999);

                // Enchant Effects
                WriteH(0x00);
                WriteH(0x00);
                WriteH(0x00);

                WriteQ((long)(si.Item.ReferencePrice * _mod * _tax));
            }
        }
    }
}