using L2dotNET.GameService.Model.Playable;
using L2dotNET.GameService.Model.Skills2;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PetInfo
    {
        private readonly L2Summon _pet;

        public PetInfo(L2Summon pet)
        {
            _pet = pet;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xb1);
            p.WriteInt(_pet.ObjectSummonType);
            p.WriteInt(_pet.ObjId);
            int npcId = _pet.Template.NpcId;
            p.WriteInt(npcId + 1000000);
            p.WriteInt(0); // 1=attackable

            p.WriteInt(_pet.X);
            p.WriteInt(_pet.Y);
            p.WriteInt(_pet.Z);
            p.WriteInt(_pet.Heading);
            p.WriteInt(0);

            double atkspd = _pet.CharacterStat.GetStat(EffectType.BAttackSpd);
            double spd = _pet.CharacterStat.GetStat(EffectType.PSpeed);
            double anim = (spd * 1f) / 130;
            double anim2 = (1.1 * atkspd) / 300;
            double runSpd = spd / anim;
            double walkSpd = (spd * .8) / anim;
            double cast = _pet.CharacterStat.GetStat(EffectType.BCastingSpd);
            p.WriteInt(cast);
            p.WriteInt(atkspd);
            p.WriteInt(runSpd);
            p.WriteInt(walkSpd);
            p.WriteInt(50);
            p.WriteInt(50);
            p.WriteInt(0);
            p.WriteInt(0);
            p.WriteInt(0);
            p.WriteInt(0);

            p.WriteDouble(anim);
            p.WriteDouble(anim2);

            p.WriteDouble(_pet.Template.CollisionRadius);
            p.WriteDouble(_pet.Template.CollisionHeight);
            p.WriteInt(0); // right hand weapon
            p.WriteInt(0); // body armor
            p.WriteInt(0); // left hand weapon

            p.WriteInt(_pet.Owner != null ? 1 : 0); // when pet is dead and player exit game, pet doesn't show master name
            p.WriteInt(_pet.IsRunning);
            p.WriteInt(_pet.isInCombat() ? 1 : 0); // attacking 1=true
            p.WriteInt(_pet.Dead ? 1 : 0);
            p.WriteInt(_pet.AppearMethod());
            p.WriteString(_pet.Name);
            p.WriteString(_pet.Title);
            p.WriteInt(1); //show title?

            p.WriteInt(_pet.GetPvPStatus());
            p.WriteInt(_pet.GetKarma());
            p.WriteInt(_pet.CurrentTime);
            p.WriteInt(_pet.MaxTime);
            p.WriteInt(_pet.CurHp);
            p.WriteInt(_pet.CharacterStat.GetStat(EffectType.BMaxHp));
            p.WriteInt(_pet.CurMp);
            p.WriteInt(_pet.CharacterStat.GetStat(EffectType.BMaxMp));

            p.WriteInt(_pet.StatusSp);
            p.WriteInt(_pet.Level);
            p.WriteInt(_pet.StatusExp);
            p.WriteInt(_pet.GetExpCurrentLevel());
            p.WriteInt(_pet.GetExpToLevelUp());

            p.WriteInt(_pet.CurrentWeight());
            p.WriteInt(_pet.MaxWeight());
            p.WriteInt(_pet.CharacterStat.GetStat(EffectType.PPhysicalAttack));
            p.WriteInt(_pet.CharacterStat.GetStat(EffectType.PPhysicalDefense));
            p.WriteInt(_pet.CharacterStat.GetStat(EffectType.PMagicalAttack));

            p.WriteInt(_pet.CharacterStat.GetStat(EffectType.PMagicalDefense));
            p.WriteInt(_pet.CharacterStat.GetStat(EffectType.BAccuracy));
            p.WriteInt(_pet.CharacterStat.GetStat(EffectType.BEvasion));
            p.WriteInt(_pet.CharacterStat.GetStat(EffectType.BCriticalRate));
            p.WriteInt(runSpd);
            p.WriteInt(atkspd);
            p.WriteInt(cast);

            p.WriteInt(_pet.AbnormalBitMask);
            p.WriteShort(_pet.IsMountable());

            p.WriteInt(0); // c2
            p.WriteShort(0); // ??

            p.WriteInt(_pet.TeamId);
            p.WriteInt(_pet.Template.SsCount);
            p.WriteInt(_pet.Template.SpsCount);
            p.WriteInt(_pet.GetForm());
            p.WriteInt(_pet.AbnormalBitMaskEx);
        }
    }
}