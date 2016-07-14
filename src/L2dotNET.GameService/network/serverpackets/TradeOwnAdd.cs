using L2dotNET.GameService.Model.Items;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TradeOwnAdd
    {
        private readonly L2Item _item;
        private readonly long _num;

        public TradeOwnAdd(L2Item item, long num)
        {
            _item = item;
            _num = num;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x1a);
            p.WriteShort(0x20);

            p.WriteShort(_item.Template.Type1);
            p.WriteInt(_item.ObjId); //item.ObjID
            p.WriteInt(_item.Template.ItemId);
            p.WriteInt(_num);

            p.WriteShort(_item.Template.Type2);
            p.WriteShort(0);

            p.WriteInt(_item.Template.BodyPart);
            p.WriteShort(_item.Enchant);
            p.WriteShort(0x00); // ?
            p.WriteShort(0x00);
        }
    }
}