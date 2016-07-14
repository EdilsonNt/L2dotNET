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

        private List<AcquireSkill> _list;
        private readonly SkillType _skillType;

        public AcquireSkillList(SkillType type)
        {
            _skillType = type;
        }

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0x8a);
            p.WriteInt((int)_skillType);
            p.WriteInt(_list.Count);

            foreach (AcquireSkill sk in _list)
            {
                p.WriteInt(sk.Id);
                p.WriteInt(sk.Lv);
                p.WriteInt(sk.Lv);
                p.WriteInt(sk.LvUpSp);
                p.WriteInt(0); //reqs
            }
        }
    }
}