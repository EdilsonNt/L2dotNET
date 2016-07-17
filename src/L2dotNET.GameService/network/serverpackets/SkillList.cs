using System.Collections.Generic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SkillList
    {
        private const byte Opcode = 0x58;

        internal static Packet ToPacket(L2Player player, int blockAct, int blockSpell, int blockSkill)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(player.Skills.Values.Count);

            foreach (Skill skill in player.Skills.Values)
            {
                int passive = skill.IsPassive();
                p.WriteInt(passive);
                p.WriteInt(skill.Level);
                p.WriteInt(skill.SkillId);

                byte blocked = 0;
                if (passive == 0)
                {
                    if (blockAct == 1)
                    {
                        blocked = 1;
                    }
                    else
                    {
                        switch (skill.IsMagic)
                        {
                            case 0:
                                blocked = (byte)blockSkill;
                                break;
                            case 1:
                                blocked = (byte)blockSpell;
                                break;
                            default:
                                blocked = 0;
                                break;
                        }
                    }
                }

                p.WriteInt(blocked);
            }
            return p;
        }
    }
}