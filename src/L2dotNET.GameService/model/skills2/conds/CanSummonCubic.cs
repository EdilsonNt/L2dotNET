﻿using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Model.Skills2.Conds
{
    public class CanSummonCubic : SkillCond
    {
        public override bool CanUse(L2Player player, Skill skill)
        {
            //int len = player.cubics.Count;
            //int max = (int)player.CharacterStat.getStat(TEffectType.p_cubic_mastery);
            //if (max == 0)
            //    max = 1;

            //return !(len + 1 > max);

            return true;
        }
    }
}