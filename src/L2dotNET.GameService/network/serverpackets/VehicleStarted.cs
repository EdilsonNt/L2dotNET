﻿namespace L2dotNET.GameService.Network.Serverpackets
{
    class VehicleStarted : GameServerNetworkPacket
    {
        private readonly int _sId;
        private readonly int _type;

        public VehicleStarted(int sId, int type)
        {
            _sId = sId;
            _type = type;
        }

        protected internal override void Write()
        {
            WriteC(0xBA);
            WriteD(_sId);
            WriteD(_type);
        }
    }
}