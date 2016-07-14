using System.Collections.Generic;
using L2dotNET.GameService.Model.Items;
using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ItemList
    {
        private readonly bool _showWindow;
        private readonly List<ItemListItem> _items = new List<ItemListItem>();
        private readonly List<int> _blocked = new List<int>();

        public ItemList(L2Player player, bool showWindow)
        {
            _showWindow = showWindow;
            foreach (L2Item item in player.Inventory.Items)
            {
                _items.Add(new ItemListItem
                           {
                               ObjectId = item.ObjId,
                               ItemId = item.Template.ItemId,
                               Slot = item.SlotLocation,
                               Count = item.Count,
                               Type2 = (short)item.Template.Type2,
                               CType1 = item.CustomType1,
                               Equip = item.IsEquipped,
                               Bodypart = item.Template.BodyPart,
                               Enchant = item.Enchant,
                               CType2 = item.CustomType2,
                               Augment = item.AugmentationId,
                               Mana = item.Durability,
                               TimeLeft = item.LifeTimeEnd()
                           });

                if (item.Blocked)
                {
                    _blocked.Add(item.ObjId);
                }
            }
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x1b);
            p.WriteShort(_showWindow ? 1 : 0);
            p.WriteShort(_items.Count);

            foreach (ItemListItem item in _items)
            {
                p.WriteInt(item.ObjectId);
                p.WriteInt(item.ItemId);
                p.WriteInt(item.Slot);
                p.WriteInt(item.Count);
                p.WriteShort(item.Type2);
                p.WriteShort(item.CType1);
                p.WriteShort(item.Equip);
                p.WriteInt(item.Bodypart);
                p.WriteShort(item.Enchant);
                p.WriteShort(item.CType2);
                p.WriteInt(item.Augment);
                p.WriteInt(item.Mana);
                //p.WriteInt(item.TimeLeft);
            }

            //p.WriteShort(blocked.Count);
            //if (blocked.Count > 0)
            //{
            //    p.WriteInt(2);
            //    foreach (int id in blocked)
            //        p.WriteInt(id);
            //}

            //items = null;
            //blocked = null;
        }
    }
}