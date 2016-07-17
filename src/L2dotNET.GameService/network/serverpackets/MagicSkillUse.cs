using L2dotNET.GameService.Model.Skills2;
using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    public class MagicSkillUse
    {
        private const byte Opcode = 0x48;

        internal static Packet ToPacket(L2Character caster, L2Object target, int skillid, int level, int hitTime, int flag = 0)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(caster.ObjId, target.ObjId);
            p.WriteInt(skillid, level);
            p.WriteInt(hitTime);
            p.WriteInt(0); //_reuseDelay
            p.WriteInt(caster.X, caster.Y, caster.Z);
            if (flag != 0)
            {
                p.WriteInt(flag);
                p.WriteShort(0x00);
            }
            else
            {
                p.WriteInt(0x00);
            }
            p.WriteInt(target.X);
            p.WriteInt(target.Y);
            p.WriteInt(target.Z);
            return p;
        }

        internal static Packet ToPacket(L2Character caster, L2Object target, Skill skill, int hitTime, int flag = 0)
        {
            return ToPacket(caster, target, skill.SkillId, skill.Level, hitTime, flag);
        }
    }
}