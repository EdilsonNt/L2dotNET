using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ChangeWaitType
    {
        private readonly int _sId;
        private readonly int _type;
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;
        public static int Sit = 0;
        public static int Stand = 1;
        public static int Fake = 2;
        public static int FakeStop = 3;

        public ChangeWaitType(L2Player player, int type)
        {
            _sId = player.ObjId;
            _x = player.X;
            _y = player.Y;
            _z = player.Z;
            _type = type;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x2f);
            p.WriteInt(_sId);
            p.WriteInt(_type);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
        }
    }
}