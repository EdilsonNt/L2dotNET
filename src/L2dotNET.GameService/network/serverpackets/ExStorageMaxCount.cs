using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExStorageMaxCount
    {
        private static int _inventory;
        private static int _warehouse;
        private static int _clan;
        private static int _privateSell;
        private static int _privateBuy;
        private static int _receipeD;
        private static int _recipe;
        
        private const short Opcode = 0x2e;
        internal static Packet ToPacket(L2Player player)
        {
            _inventory = player.ItemLimitInventory;
            _warehouse = player.ItemLimitWarehouse;
            _clan = player.ItemLimitClanWarehouse;
            _privateSell = player.ItemLimitSelling;
            _privateBuy = player.ItemLimitBuying;
            _receipeD = player.ItemLimitRecipeDwarven;
            _recipe = player.ItemLimitWarehouse;
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);

            p.WriteInt(_inventory);
            p.WriteInt(_warehouse);
            p.WriteInt(_clan);
            p.WriteInt(_privateSell);
            p.WriteInt(_privateBuy);
            p.WriteInt(_receipeD);
            p.WriteInt(_recipe);
            //p.WriteInt(_extra);
            //p.WriteInt(_quest);
            return p;
        }
    }
}