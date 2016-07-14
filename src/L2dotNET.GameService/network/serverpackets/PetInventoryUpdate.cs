using System.Collections.Generic;
using L2dotNET.GameService.Model.Items;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PetInventoryUpdate
    {
        protected List<object[]> Update = new List<object[]>();

        public void AddNewItem(L2Item item)
        {
            Update.Add(new object[] { item, (short)1 });
        }

        public void AddModItem(L2Item item)
        {
            Update.Add(new object[] { item, (short)2 });
        }

        public void AddDelItem(L2Item item)
        {
            Update.Add(new object[] { item, (short)3 });
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xb4);
            p.WriteShort(Update.Count);

            foreach (object[] obj in Update)
            {
                p.WriteShort((short)obj[1]);

                L2Item item = (L2Item)obj[0];

                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(0); //loc
                p.WriteInt(item.Count);

                p.WriteShort(item.Template.Type2);
                p.WriteShort(0);
                p.WriteShort(item.IsEquipped);

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