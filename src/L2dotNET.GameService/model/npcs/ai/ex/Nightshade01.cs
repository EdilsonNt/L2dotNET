﻿using L2dotNET.GameService.Model.Playable;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;

namespace L2dotNET.GameService.Model.Npcs.Ai.Ex
{
    class Nightshade01 : AiTemplate
    {
        public override void OnActionClicked(L2Player player, L2Summon pet, int actionId)
        {
            string value = null;
            switch (actionId)
            {
                case 1013:
                    value = "DeBuff1";
                    break;
                case 1014:
                    value = "DeBuff2";
                    break;
                case 1015:
                    value = "Heal";
                    break;

                default:
                    if (actionId == GetValueInt("buff_action3"))
                    {
                        value = "buff3";
                    }
                    else if (actionId == GetValueInt("buff_action4"))
                    {
                        value = "buff4";
                    }
                    else if (actionId == GetValueInt("buff_action5"))
                    {
                        value = "buff5";
                    }
                    break;
            }

            if (value == null)
            {
                return;
            }

            int[] skill = GetValueSkill(value);
            pet.CastSkill(SkillTable.Instance.Get(skill[0], skill[1]));
        }
    }
}