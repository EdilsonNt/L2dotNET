﻿namespace L2dotNET.GameService.Network.Serverpackets
{
    class ChooseInventoryItem
    {
        private readonly int _itemId;

        public ChooseInventoryItem(int itemId)
        {
            _itemId = itemId;
        }

        protected internal override void Write()
        {
            WriteC(0x6f);
            WriteD(_itemId);
        }
    }
}