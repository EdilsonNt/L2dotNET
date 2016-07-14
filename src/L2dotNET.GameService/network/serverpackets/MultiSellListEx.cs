using L2dotNET.GameService.Tables.Multisell;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class MultiSellListEx
    {
        private readonly MultiSellList _list;

        public MultiSellListEx(MultiSellList list)
        {
            _list = list;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xd0);
            p.WriteInt(_list.Id);
            p.WriteInt(1); // page
            p.WriteInt(1); // finished
            p.WriteInt(_list.Container.Count); // size of pages 40
            p.WriteInt(_list.Container.Count);

            int inc = 0;
            foreach (MultiSellEntry entry in _list.Container)
            {
                p.WriteInt(inc);
                inc++;
                p.WriteInt(entry.Stackable);
                p.WriteShort(entry.Enchant);
                p.WriteInt(0x00); // C6
                p.WriteInt(0x00); // T1

                p.WriteShort(entry.AttrAttackType);
                p.WriteShort(entry.AttrAttackValue);
                p.WriteShort(entry.AttrDefenseValueFire);
                p.WriteShort(entry.AttrDefenseValueWater);
                p.WriteShort(entry.AttrDefenseValueWind);
                p.WriteShort(entry.AttrDefenseValueEarth);
                p.WriteShort(entry.AttrDefenseValueHoly);
                p.WriteShort(entry.AttrDefenseValueUnholy);

                p.WriteShort(entry.Give.Count);
                p.WriteShort(entry.Take.Count);

                foreach (MultiSellItem item in entry.Give)
                {
                    p.WriteInt(item.ItemId);
                    p.WriteInt(item.BodyPartId);
                    p.WriteShort(item.Type2);
                    p.WriteInt(item.Count);
                    p.WriteShort(item.Enchant);
                    p.WriteInt(item.Augment);
                    p.WriteInt(item.Durability);
                }

                foreach (MultiSellItem item in entry.Take)
                {
                    p.WriteInt(item.ItemId);
                    p.WriteShort(item.Type2);
                    p.WriteInt(item.Count);
                    p.WriteShort(item.Enchant);
                    p.WriteInt(item.Augment);
                    p.WriteInt(item.Durability);
                }
            }
        }
    }
}