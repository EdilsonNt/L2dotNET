using L2dotNET.GameService.Model.Playable;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PetInfo
    {
        private const byte Opcode = 0xb1;

        internal static Packet ToPacket(L2Summon pet)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(pet.ObjectSummonType);
            p.WriteInt(pet.ObjId);
            p.WriteInt(pet.NpcHashId);
            p.WriteInt(0); // 1=attackable

            p.WriteInt(pet.X);
            p.WriteInt(pet.Y);
            p.WriteInt(pet.Z);
            p.WriteInt(pet.Heading);
            p.WriteInt(0);

            double atkspd = pet.CharacterStat.GetStat(EffectType.BAttackSpd);
            double spd = pet.CharacterStat.GetStat(EffectType.PSpeed);
            double anim = (spd * 1f) / 130;
            double anim2 = (1.1 * atkspd) / 300;
            double runSpd = spd / anim;
            double walkSpd = (spd * .8) / anim;
            double cast = pet.CharacterStat.GetStat(EffectType.BCastingSpd);
            p.WriteInt((int)cast);
            p.WriteInt((int)atkspd);
            p.WriteInt((int)runSpd);
            p.WriteInt((int)walkSpd);
            p.WriteInt((int)runSpd);// swim
            p.WriteInt((int)walkSpd);
            p.WriteInt((int)runSpd);// no clue
            p.WriteInt((int)walkSpd);
            p.WriteInt((int)runSpd);// fly
            p.WriteInt((int)walkSpd);

            p.WriteDouble(anim);
            p.WriteDouble(anim2);

            p.WriteDouble(pet.Template.CollisionRadius);
            p.WriteDouble(pet.Template.CollisionHeight);
            p.WriteInt(pet.Template.RHand); // right hand weapon
            p.WriteInt(0); // body armor
            p.WriteInt(0); // left hand weapon

            p.WriteByte(pet.Owner != null ? (byte)1 : (byte)0); // when pet is dead and player exit game, pet doesn't show master name
            p.WriteByte(pet.IsRunning);
            p.WriteByte(pet.isInCombat() ? (byte)1 : (byte)0); // attacking 1=true
            p.WriteByte(pet.Dead ? (byte)1 : (byte)0);
            p.WriteByte(pet.AppearMethod());
            p.WriteString(pet.Name);
            p.WriteString(pet.Title);
            p.WriteInt(1); //show title?

            p.WriteInt(pet.GetPvPStatus());
            p.WriteInt(pet.GetKarma());
            p.WriteInt(pet.CurrentTime);
            p.WriteInt(pet.MaxTime);
            p.WriteInt((int)pet.CurHp);
            p.WriteInt(pet.MaxHp);
            p.WriteInt((int)pet.CurMp);
            p.WriteInt(pet.MaxHp);

            p.WriteInt(pet.StatusSp);
            p.WriteInt(pet.Level);
            p.WriteLong(pet.StatusExp);
            p.WriteLong(pet.GetExpCurrentLevel());
            p.WriteLong(pet.GetExpToLevelUp());

            p.WriteInt(pet.CurrentWeight());
            p.WriteInt(pet.MaxWeight());
            p.WriteInt((int)pet.CharacterStat.GetStat(EffectType.PPhysicalAttack));
            p.WriteInt((int)pet.CharacterStat.GetStat(EffectType.PPhysicalDefense));
            p.WriteInt((int)pet.CharacterStat.GetStat(EffectType.PMagicalAttack));

            p.WriteInt((int)pet.CharacterStat.GetStat(EffectType.PMagicalDefense));
            p.WriteInt((int)pet.CharacterStat.GetStat(EffectType.BAccuracy));
            p.WriteInt((int)pet.CharacterStat.GetStat(EffectType.BEvasion));
            p.WriteInt((int)pet.CharacterStat.GetStat(EffectType.BCriticalRate));
            p.WriteInt((int)runSpd);
            p.WriteInt((int)atkspd);
            p.WriteInt((int)cast);

            p.WriteInt(pet.AbnormalBitMask);
            p.WriteShort(pet.IsMountable());

            p.WriteByte(0); // c2
            p.WriteShort(0); // ??

            p.WriteInt(pet.TeamId);
            p.WriteInt(pet.Template.SsCount);
            p.WriteInt(pet.Template.SpsCount);
            return p;
        }
    }
}