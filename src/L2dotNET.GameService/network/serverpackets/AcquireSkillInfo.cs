using System.Collections.Generic;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class AcquireSkillInfo
    {
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

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0x8b);
            p.WriteInt(_id);
            p.WriteInt(_level);
            p.WriteInt(_spCost);
            p.WriteInt(_mode);

            p.WriteInt(Reqs.Count);

            foreach (int[] r in Reqs)
            {
                p.WriteInt(r[0]);
                p.WriteInt(r[1]);
                p.WriteInt(r[2]);
                p.WriteInt(r[3]);
            }
        }
    }
}