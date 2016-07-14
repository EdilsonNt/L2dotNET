using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Tables;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExBuySellListBuy
    {
        private const short Opcode = 0xB7;
        
        internal static Packet ToPacket(L2Player player, NdShopList shop, double mod, double tax, int shopId)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(0);
            p.WriteInt(player.GetAdena());
            p.WriteInt(shopId);

            if (shop == null)
            {
                p.WriteShort(0);
                return p;
            }

            p.WriteShort((short)shop.Items.Count);
            foreach (NDShopItem si in shop.Items)
            {
                p.WriteInt(0); //objectId
                p.WriteInt(si.Item.ItemId);
                p.WriteInt(0);
                p.WriteInt(si.Count < 0 ? 0 : si.Count);
                p.WriteShort((short)si.Item.Type2);
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

                p.WriteInt((int)(si.Item.ReferencePrice * mod * tax));
            }
            return p;
        }
    }
}