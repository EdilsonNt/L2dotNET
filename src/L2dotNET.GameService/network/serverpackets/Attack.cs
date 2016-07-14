using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class Attack
    {
        protected int AttackerObjId;
        public bool Soulshot;
        public int Grade;
        private readonly int _x;
        private int _tx;
        private readonly int _y;
        private int _ty;
        private readonly int _z;
        private int _tz;
        private Hit[] _hits;

        public Attack(L2Character player, L2Object target, bool ss, int grade)
        {
            AttackerObjId = player.ObjId;
            Soulshot = ss;
            Grade = grade;
            _x = player.X;
            _y = player.Y;
            _z = player.Z;
            _tx = target.X;
            _ty = target.Y;
            _tz = target.Z;
            _hits = new Hit[0];
        }

        public void AddHit(int targetId, int damage, bool miss, bool crit, bool shld)
        {
            int pos = _hits.Length;
            Hit[] tmp = new Hit[pos + 1];

            for (int i = 0; i < _hits.Length; i++)
            {
                tmp[i] = _hits[i];
            }

            tmp[pos] = new Hit(targetId, damage, miss, crit, shld, Soulshot, Grade);
            _hits = tmp;
        }

        public bool HasHits()
        {
            return _hits.Length > 0;
        }

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0x05);

            p.WriteInt(AttackerObjId);
            p.WriteInt(_hits[0].TargetId);
            p.WriteInt(_hits[0].Damage);
            p.WriteInt(_hits[0].Flags);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
            p.WriteShort((short)(_hits.Length - 1));
            for (int i = 1; i < _hits.Length; i++)
            {
                p.WriteInt(_hits[i].TargetId);
                p.WriteInt(_hits[i].Damage);
                p.WriteInt(_hits[i].Flags);
            }
        }
    }
}