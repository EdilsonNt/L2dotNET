using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class Attack
    {
        private const byte Opcode = 0x05;
        private static Hit[] _hits = new Hit[0];

        public void AddHit(int targetId, int damage, bool miss, bool crit, bool shld, bool soulshot, int grade)
        {
            int pos = _hits.Length;
            Hit[] tmp = new Hit[pos + 1];

            for (int i = 0; i < _hits.Length; i++)
            {
                tmp[i] = _hits[i];
            }

            tmp[pos] = new Hit(targetId, damage, miss, crit, shld, soulshot, grade);
            _hits = tmp;
        }

        public bool HasHits()
        {
            return _hits.Length > 0;
        }

        internal static Packet ToPacket(L2Character player, L2Object target, bool ss, int grade)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(player.ObjId, _hits[0].TargetId,_hits[0].Damage);
            p.WriteByte((byte)_hits[0].Flags);
            p.WriteInt(player.X, player.Y, player.Z);
            p.WriteShort((short)(_hits.Length - 1));
            for (int i = 1; i < _hits.Length; i++)
            {
                p.WriteInt(_hits[i].TargetId, _hits[i].Damage);
                p.WriteByte((byte)_hits[i].Flags);
            }
            return p;
        }
    }
}