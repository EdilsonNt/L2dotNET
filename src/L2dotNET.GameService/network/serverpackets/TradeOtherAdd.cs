using L2dotNET.GameService.Model.Items;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TradeOtherAdd
    {
        private readonly L2Item _item;
        private long _num;

        public TradeOtherAdd(L2Item item, long num)
        {
            _item = item;
            _num = num;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x20);
            p.WriteShort(1);

            p.WriteShort(_item.Template.Type1);
            p.WriteInt(0); //item.ObjID
            p.WriteInt(_item.Template.ItemId);
            p.WriteInt(_item.Count);

            p.WriteShort(_item.Template.Type2);
            p.WriteShort(0); // ??

            p.WriteInt(_item.Template.BodyPart);
            p.WriteShort(_item.Enchant);
            p.WriteShort(0x00); // ?
            p.WriteShort(0x00);
        }
    }
}