﻿namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharCreateOk
    {
        protected internal override void Write()
        {
            WriteC(0x19);
            WriteD(0x01);
        }
    }
}