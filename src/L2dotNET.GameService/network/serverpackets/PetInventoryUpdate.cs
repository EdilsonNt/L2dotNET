using System.Collections.Generic;
using L2dotNET.GameService.Model.Items;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PetInventoryUpdate
    {
        private const byte Opcode = 0xb4;
        protected static List<object[]> Update = new List<object[]>();

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
            Packet p = new Packet(Opcode);
            p.WriteShort((short)Update.Count);

            foreach (object[] obj in Update)
            {
                p.WriteShort((short)obj[1]);
                p.WriteShort(0);
                L2Item item = (L2Item)obj[0];

                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(item.Count);

                p.WriteShort((short)item.Template.Type2);
                p.WriteShort(0);
                p.WriteShort(item.IsEquipped);

                p.WriteInt(item.Template.BodyPart);
                p.WriteShort(item.Enchant);
                p.WriteShort((short)item.Template.Type2);//get customtype2
            }
            return p;
        }
    }
}