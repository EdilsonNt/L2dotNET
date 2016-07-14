using System.Collections.Generic;
using L2dotNET.GameService.Model.Items;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExPostItemList
    {
        private readonly List<L2Item> _list;

        public ExPostItemList(List<L2Item> list)
        {
            _list = list;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0xb2);
            p.WriteInt(_list.Count);

            foreach (L2Item item in _list)
            {
                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(0);
                p.WriteInt(item.Count);

                p.WriteShort(item.Template.Type2);
                p.WriteShort(0);
                p.WriteShort(0);

                p.WriteInt(item.Template.BodyPart);
                p.WriteShort(item.Enchant);
                p.WriteShort(0);

                p.WriteInt(item.AugmentationId);
                p.WriteInt(item.Durability);
                p.WriteInt(item.LifeTimeEnd());

                p.WriteShort(item.AttrAttackType);
                p.WriteShort(item.AttrAttackValue);
                p.WriteShort(item.AttrDefenseValueFire);
                p.WriteShort(item.AttrDefenseValueWater);
                p.WriteShort(item.AttrDefenseValueWind);
                p.WriteShort(item.AttrDefenseValueEarth);
                p.WriteShort(item.AttrDefenseValueHoly);
                p.WriteShort(item.AttrDefenseValueUnholy);

                p.WriteShort(item.Enchant1);
                p.WriteShort(item.Enchant2);
                p.WriteShort(item.Enchant3);
            }
        }
    }
}