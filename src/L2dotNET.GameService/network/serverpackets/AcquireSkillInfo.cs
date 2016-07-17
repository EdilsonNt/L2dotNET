using System.Collections.Generic;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class AcquireSkillInfo
    {
        private const byte Opcode = 0x8b;

        private readonly int _id;
        private readonly int _level;
        private readonly int _spCost;
        private readonly int _mode;
        public List<int[]> Reqs = new List<int[]>();

        public AcquireSkillInfo(int id, int level, int sp, int skillType)
        {
            _id = id;
            _level = level;
            _spCost = sp;
            _mode = skillType;
        }

        internal Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(_id, _level, _spCost, _mode, Reqs.Count);

            foreach (int[] r in Reqs)
            {
                p.WriteInt(r[0], r[1], r[2], r[3]);
            }

            return p;
        }
    }
}