﻿using L2dotNET.GameService.Model.Items;

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

        protected internal override void Write()
        {
            WriteC(0x1a);
            WriteH(0x20);

            WriteH(_item.Template.Type1);
            WriteD(_item.ObjId); //item.ObjID
            WriteD(_item.Template.ItemId);
            WriteD(_num);

            WriteH(_item.Template.Type2);
            WriteH(0);

            WriteD(_item.Template.BodyPart);
            WriteH(_item.Enchant);
            WriteH(0x00); // ?
            WriteH(0x00);
        }
    }
}