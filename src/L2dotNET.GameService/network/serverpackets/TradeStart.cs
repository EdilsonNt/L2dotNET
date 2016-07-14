using System.Collections.Generic;
using L2dotNET.GameService.Model.Items;
using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TradeStart
    {
        private L2Player _player;
        private readonly List<L2Item> _trade = new List<L2Item>();
        private readonly int _partnerId;

        public TradeStart(L2Player player)
        {
            _player = player;
            _partnerId = player.Requester.ObjId;
            //foreach (L2Item item in player.getAllNonQuestItems().Where(item => (item.Template.is_trade != 0) && (item.AugmentationID <= 0) && (item._isEquipped != 1) && (item.Template.Type != ItemTemplate.L2ItemType.asset)))
            //    trade.Add(item);
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x1E);
            p.WriteInt(_partnerId);
            p.WriteShort(_trade.Count);

            foreach (L2Item item in _trade)
            {
                p.WriteShort(item.Template.Type1);
                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(item.Count);

                p.WriteShort(item.Template.Type2);
                p.WriteShort(item.CustomType1);

                p.WriteInt(item.Template.BodyPart);
                p.WriteShort(item.Enchant);
                p.WriteShort(item.CustomType2);

                p.WriteShort(0x00);
            }
        }
    }
}