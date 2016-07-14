using System.Collections.Generic;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class AcquireSkillList
    {
        public enum SkillType
        {
            Usual = 0,
            Fishing = 1,
            Clan = 2
        }

        private const byte Opcode = 0x8a;

        private static readonly List<AcquireSkill> _list = new List<AcquireSkill>();

        internal static Packet ToPacket(SkillType type)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt((int)type, _list.Count);

            foreach (AcquireSkill sk in _list)
            {
                p.WriteInt(sk.Id, sk.Lv, sk.Lv, sk.LvUpSp, 0); //reqs
            }
            return p;
        }
    }
}