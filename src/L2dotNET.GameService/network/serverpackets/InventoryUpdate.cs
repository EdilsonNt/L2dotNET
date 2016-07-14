using System.Collections.Generic;
using L2dotNET.GameService.Model.Items;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class InventoryUpdate
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
            p.WriteInt(0x27);
            p.WriteShort(Update.Count);

            foreach (object[] obj in Update)
            {
                p.WriteShort((short)obj[1]);

                L2Item item = (L2Item)obj[0];

                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(item.SlotLocation); //loc
                p.WriteInt(item.Count);

                p.WriteShort(item.Template.Type2);
                p.WriteShort(item.CustomType1);
                p.WriteShort(item.IsEquipped);

                p.WriteInt(item.Template.BodyPart);
                p.WriteShort(item.Enchant);
                p.WriteShort(item.CustomType2);

                p.WriteInt(item.AugmentationId);
                p.WriteInt(item.Durability);
                //p.WriteInt(item.LifeTimeEnd());
            }
        }
    }
}