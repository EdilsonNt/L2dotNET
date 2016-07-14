using System.Collections.Generic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SkillCoolTime
    {
        private readonly ICollection<L2SkillCoolTime> _list;

        public SkillCoolTime(L2Player player)
        {
            _list = player.Reuse.Values;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xc1);
            p.WriteInt(_list.Count);

            foreach (L2SkillCoolTime ct in _list)
            {
                p.WriteInt(ct.Id);
                p.WriteInt(ct.Lvl);
                p.WriteInt(ct.Total);
                p.WriteInt(ct.GetDelay());
            }
        }
    }
}