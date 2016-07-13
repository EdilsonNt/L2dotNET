﻿namespace L2dotNET.GameService.Network.Serverpackets
{
    class RadarControl
    {
        private readonly int _showRadar;
        private readonly int _type;
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;

        public RadarControl(int showRadar, int type, int x, int y, int z)
        {
            _showRadar = showRadar; // 0 = showradar; 1 = delete radar;
            _type = type;
            _x = x;
            _y = y;
            _z = z;
        }

        protected internal override void Write()
        {
            WriteC(0xEB);
            WriteD(_showRadar);
            WriteD(_type);
            WriteD(_x);
            WriteD(_y);
            WriteD(_z);
        }
    }
}