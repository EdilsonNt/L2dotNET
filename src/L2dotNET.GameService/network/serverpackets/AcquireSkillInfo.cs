using System.Collections.Generic;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class AcquireSkillInfo
    {
        private const byte Opcode = 0x8b;

        public static List<int[]> Reqs = new List<int[]>();

        internal static Packet ToPacket(int id, int level, int sp, int skillType)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(id, level, sp, skillType, Reqs.Count);

            foreach (int[] r in Reqs)
            {
                p.WriteInt(r[0], r[1], r[2], r[3]);
            }

            return p;
        }
    }
}