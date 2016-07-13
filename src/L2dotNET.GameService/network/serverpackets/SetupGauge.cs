﻿namespace L2dotNET.GameService.Network.Serverpackets
{
    class SetupGauge
    {
        public enum SgColor
        {
            Blue = 0,
            Red = 1,
            Cyan = 2,
            Green = 3
        }

        private readonly SgColor _color;
        private readonly int _time;
        private int _id;

        public SetupGauge(int id, SgColor color, int time)
        {
            _id = id;
            _color = color;
            _time = time;
        }

        protected internal override void Write()
        {
            WriteC(0x6d);
            //writeD(_id);
            WriteD((int)_color);
            WriteD(_time);
            WriteD(_time); //c2
        }
    }
}