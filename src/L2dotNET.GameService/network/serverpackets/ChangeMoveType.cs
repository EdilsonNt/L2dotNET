using System;
using L2dotNET.GameService.World;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ChangeMoveType
    {
        public static readonly int Walk = 0;
        public static readonly int Run = 1;

        private readonly int _charObjId;
        private readonly bool _running;

        public ChangeMoveType(L2Character character)
        {
            _charObjId = character.ObjId;
            _running = Convert.ToBoolean(character.IsRunning);
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x2e);
            p.WriteInt(_charObjId);
            p.WriteInt(_running ? Run : Walk);
            p.WriteInt(0); // c2
        }
    }
}