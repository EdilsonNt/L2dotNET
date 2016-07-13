﻿using L2dotNET.GameService.World;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharFlyToLocation
    {
        private readonly L2Object _obj;
        private readonly int _id;

        public CharFlyToLocation(L2Object obj, FlyType type)
        {
            _obj = obj;
            _id = (int)type;
        }

        protected internal override void Write()
        {
            WriteC(0xC5);

            WriteD(_obj.ObjId);

            WriteD(_obj.DestX);
            WriteD(_obj.DestY);
            WriteD(_obj.DestZ);

            WriteD(_obj.X);
            WriteD(_obj.Y);
            WriteD(_obj.Z);

            WriteD(_id);
        }
    }
}