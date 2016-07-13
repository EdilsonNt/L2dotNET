﻿namespace L2dotNET.GameService.Network.Serverpackets
{
    class StopRotation : GameServerNetworkPacket
    {
        private readonly int _sId;
        private readonly int _degree;
        private readonly int _speed;

        public StopRotation(int sId, int degree, int speed)
        {
            _sId = sId;
            _degree = degree;
            _speed = speed;
        }

        protected internal override void Write()
        {
            WriteC(0x63);
            WriteD(_sId);
            WriteD(_degree);
            WriteD(_speed);
            WriteC(_degree);
        }
    }
}