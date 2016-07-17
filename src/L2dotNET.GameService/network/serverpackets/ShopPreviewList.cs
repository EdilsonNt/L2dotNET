using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Tables;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ShopPreviewList
    {
        private const byte Opcode = 0xef;

        internal static Packet ToPacket(L2Player player, NdShopList shop, int shopId)
        {
            Packet p = new Packet(Opcode);
            p.WriteByte(0xc0); // ?
            p.WriteByte(0x13); // ?
            p.WriteByte(0x00); // ?
            p.WriteByte(0x00); // ?
            p.WriteInt(player.GetAdena());
            p.WriteInt(shopId);

            foreach (NDShopItem si in shop.Items)
            {
                p.WriteInt(si.Item.ItemId);
                p.WriteShort((short)si.Item.Type2);
                p.WriteShort((short)si.Item.BodyPart);
                p.WriteInt(10); // wear price??
            }
            return p;
        }
    }
}