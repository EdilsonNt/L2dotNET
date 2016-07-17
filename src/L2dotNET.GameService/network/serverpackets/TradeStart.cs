using System.Collections.Generic;
using L2dotNET.GameService.Model.Items;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TradeStart
    {
        private const byte Opcode = 0x1E;
        private static List<L2Item> trade = new List<L2Item>();

        internal static Packet ToPacket(L2Player player)
        {
            //foreach (L2Item item in player.getAllNonQuestItems().Where(item => (item.Template.is_trade != 0) && (item.AugmentationID <= 0) && (item._isEquipped != 1) && (item.Template.Type != ItemTemplate.L2ItemType.asset)))
            //    trade.Add(item);
            Packet p =  new Packet(Opcode);
            p.WriteInt(player.Requester.ObjId);
            p.WriteShort((short)trade.Count);

            foreach (L2Item item in trade)
            {
                p.WriteShort((short)item.Template.Type1);
                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(item.Count);

                p.WriteShort((short)item.Template.Type2);
                p.WriteShort(item.CustomType1);

                p.WriteInt(item.Template.BodyPart);
                p.WriteShort(item.Enchant);
                p.WriteShort(item.CustomType2);

                p.WriteShort(0x00);
            }
            return p;
        }
    }
}