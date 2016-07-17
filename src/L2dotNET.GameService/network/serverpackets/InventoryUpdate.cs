using System.Collections.Generic;
using L2dotNET.GameService.Model.Items;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class InventoryUpdate
    {
        protected static List<object[]> Update = new List<object[]>();
        private const byte Opcode = 0x27;

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

        internal Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteShort((short)Update.Count);

            foreach (object[] obj in Update)
            {
                p.WriteShort((short)obj[1]);

                L2Item item = (L2Item)obj[0];

                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(item.SlotLocation); //loc
                p.WriteInt(item.Count);

                p.WriteShort((short)item.Template.Type2);
                p.WriteShort((short)item.CustomType1);
                p.WriteShort(item.IsEquipped);

                p.WriteInt(item.Template.BodyPart);
                p.WriteShort((short)item.Enchant);
                p.WriteShort((short)item.CustomType2);

                p.WriteInt(item.AugmentationId);
                p.WriteInt(item.Durability);
                //p.WriteInt(item.LifeTimeEnd());
            }
            return p;
        }
    }
}