using L2dotNET.GameService.Model.Items;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExRpItemLink
    {
        private readonly L2Item _item;

        public ExRpItemLink(L2Item item)
        {
            _item = item;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x6c);

            p.WriteInt(_item.ObjId);
            p.WriteInt(_item.Template.ItemId);
            p.WriteInt(0);
            p.WriteInt(_item.Count);
            p.WriteShort(_item.Template.Type2);
            p.WriteShort(0);
            p.WriteShort(0);
            p.WriteInt(_item.Template.BodyPart);
            p.WriteShort(_item.Enchant);
            p.WriteShort(0);
            p.WriteInt(_item.AugmentationId);
            p.WriteInt(_item.Durability);
            p.WriteInt(_item.LifeTimeEnd());

            p.WriteShort(_item.AttrAttackType);
            p.WriteShort(_item.AttrAttackValue);
            p.WriteShort(_item.AttrDefenseValueFire);
            p.WriteShort(_item.AttrDefenseValueWater);
            p.WriteShort(_item.AttrDefenseValueWind);
            p.WriteShort(_item.AttrDefenseValueEarth);
            p.WriteShort(_item.AttrDefenseValueHoly);
            p.WriteShort(_item.AttrDefenseValueUnholy);

            p.WriteShort(_item.Enchant1);
            p.WriteShort(_item.Enchant2);
            p.WriteShort(_item.Enchant3);
        }
    }
}