using L2dotNET.GameService.Model.Items;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TradeUpdate
    {
        private readonly L2Item _item;
        private readonly long _num;
        private readonly byte _action;

        public TradeUpdate(L2Item item, long num, byte action)
        {
            _item = item;
            _num = num;
            _action = action;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x74);
            p.WriteShort(1);
            p.WriteShort(_action);

            p.WriteShort(_item.Template.Type1);
            p.WriteInt(_item.ObjId);
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