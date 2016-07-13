﻿using L2dotNET.GameService.World;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TargetSelected
    {
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;
        private readonly int _objectId;
        private readonly int _targetObjId;

        public TargetSelected(int selecterId, L2Object target)
        {
            _objectId = selecterId;
            _targetObjId = target.ObjId;
            _x = target.X;
            _y = target.Y;
            _z = target.Z;
        }

        protected internal override void Write()
        {
            WriteC(0x29);
            WriteD(_objectId);
            WriteD(_targetObjId);
            WriteD(_x);
            WriteD(_y);
            WriteD(_z);
        }
    }
}