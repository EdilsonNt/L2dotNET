﻿namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExPutEnchantTargetItemResult
    {
        private readonly int _result;

        public ExPutEnchantTargetItemResult(int result = 0)
        {
            _result = result;
        }

        protected internal override void Write()
        {
            WriteC(0xfe);
            WriteH(0x81);
            WriteD(_result);
        }
    }
}