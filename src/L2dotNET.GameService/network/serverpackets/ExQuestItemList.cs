using System.Collections.Generic;
using System.Linq;
using L2dotNET.GameService.Model.Items;
using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExQuestItemList
    {
        private readonly L2Item[] _items;
        private readonly List<int> _block = new List<int>();

        public ExQuestItemList(L2Player player)
        {
            _items = new L2Item[] {}; //player.getAllQuestItems();

            if (_items == null)
            {
                return;
            }

            foreach (L2Item item in _items.Where(item => item.Blocked))
            {
                _block.Add(item.ObjId);
            }
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0xC5);
            //p.WriteShort(_items.Length);

            //foreach (L2Item item in _items)
            //{
            //    p.WriteInt(item.ObjId);
            //    p.WriteInt(item.Template.ItemId);
            //    p.WriteInt(0);
            //    p.WriteInt(item.Count);

            //    p.WriteShort(item.Template.Type2);
            //    p.WriteShort(0);
            //    p.WriteShort(item.IsEquipped);

            //    p.WriteInt(item.Template.BodyPart);
            //    p.WriteShort(item.Enchant);
            //    p.WriteShort(0);

            //    p.WriteInt(item.AugmentationId);
            //    p.WriteInt(item.Durability);
            //    p.WriteInt(item.LifeTimeEnd());

            //    p.WriteShort(item.AttrAttackType);
            //    p.WriteShort(item.AttrAttackValue);
            //    p.WriteShort(item.AttrDefenseValueFire);
            //    p.WriteShort(item.AttrDefenseValueWater);
            //    p.WriteShort(item.AttrDefenseValueWind);
            //    p.WriteShort(item.AttrDefenseValueEarth);
            //    p.WriteShort(item.AttrDefenseValueHoly);
            //    p.WriteShort(item.AttrDefenseValueUnholy);

            //    p.WriteShort(item.Enchant1);
            //    p.WriteShort(item.Enchant2);
            //    p.WriteShort(item.Enchant3);
            //}

            //p.WriteShort(_block.Count);
            //if (_block.Count <= 0)
            //{
            //    return;
            //}

            //p.WriteInt(1);
            //foreach (int id in _block)
            //{
            //    p.WriteInt(id);
            //}
        }
    }
}