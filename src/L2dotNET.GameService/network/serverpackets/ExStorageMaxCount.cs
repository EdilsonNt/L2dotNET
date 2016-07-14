using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExStorageMaxCount
    {
        private readonly int _inventory;
        private readonly int _warehouse;
        private readonly int _clan;
        private readonly int _privateSell;
        private readonly int _privateBuy;
        private readonly int _receipeD;
        private readonly int _recipe;
        //private int _extra;
        //private int _quest;

        public ExStorageMaxCount(L2Player player)
        {
            _inventory = player.ItemLimitInventory;
            _warehouse = player.ItemLimitWarehouse;
            _clan = player.ItemLimitClanWarehouse;
            _privateSell = player.ItemLimitSelling;
            _privateBuy = player.ItemLimitBuying;
            _receipeD = player.ItemLimitRecipeDwarven;
            _recipe = player.ItemLimitWarehouse;
            //_extra = player.ItemLimit_Extra;
            //_quest = player.ItemLimit_Quest;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x2e);

            p.WriteInt(_inventory);
            p.WriteInt(_warehouse);
            p.WriteInt(_clan);
            p.WriteInt(_privateSell);
            p.WriteInt(_privateBuy);
            p.WriteInt(_receipeD);
            p.WriteInt(_recipe);
            //p.WriteInt(_extra);
            //p.WriteInt(_quest);
        }
    }
}