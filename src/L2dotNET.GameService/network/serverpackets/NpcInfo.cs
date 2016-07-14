using L2dotNET.GameService.Model.Npcs;
using L2dotNET.GameService.Model.Skills2;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class NpcInfo
    {
        private readonly L2Npc _npc;

        public NpcInfo(L2Npc npc)
        {
            _npc = npc;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x0c);
            p.WriteInt(_npc.ObjId);
            p.WriteInt(_npc.NpcHashId);
            p.WriteInt(_npc.Attackable);
            p.WriteInt(_npc.X);
            p.WriteInt(_npc.Y);
            p.WriteInt(_npc.Z);
            p.WriteInt(_npc.Heading);
            p.WriteInt(0x00);

            double spd = _npc.CharacterStat.GetStat(EffectType.PSpeed);
            double atkspd = _npc.CharacterStat.GetStat(EffectType.BAttackSpd);
            double cast = _npc.CharacterStat.GetStat(EffectType.BCastingSpd);
            double anim = (spd * 1f) / 120;
            double anim2 = (1.1 * atkspd) / 277;

            p.WriteInt(cast);
            p.WriteInt(atkspd);
            p.WriteInt(spd);
            p.WriteInt(spd * .8);
            p.WriteInt(0); // swimspeed
            p.WriteInt(0); // swimspeed
            p.WriteInt(0);
            p.WriteInt(0);
            p.WriteInt(0);
            p.WriteInt(0);

            p.WriteDouble(anim);
            p.WriteDouble(anim2);
            p.WriteDouble(_npc.Radius);
            p.WriteDouble(_npc.Height);
            p.WriteInt(_npc.Template.RHand); // right hand weapon
            p.WriteInt(0);
            p.WriteInt(_npc.Template.LHand); // left hand weapon
            p.WriteInt(1); // name above char 1=true ... ??
            p.WriteInt(_npc.isRunning());
            p.WriteInt(_npc.isInCombat() ? 1 : 0);
            p.WriteInt(_npc.IsAlikeDead());
            p.WriteInt(_npc.Summoned ? 2 : 0); // invisible ?? 0=false  1=true   2=summoned (only works if model has a summon animation)
            p.WriteString(_npc.Name);
            p.WriteString(_npc.Template.Title);
            p.WriteInt(0x00); // Title color 0=client default
            p.WriteInt(0x00); //pvp flag
            p.WriteInt(0x00); // karma

            p.WriteInt(_npc.AbnormalBitMask);
            p.WriteInt(_npc.ClanId);
            p.WriteInt(_npc.ClanCrestId);
            p.WriteInt(_npc.AllianceId);
            p.WriteInt(_npc.AllianceCrestId);
            p.WriteInt(_npc.IsFlying() ? 2 : 0); // C2

            p.WriteInt(_npc.TeamId);
            p.WriteDouble(_npc.Template.CollisionRadius);
            p.WriteDouble(_npc.Template.CollisionHeight);
            p.WriteInt(0); // enchant
            p.WriteInt(_npc.IsFlying() ? 1 : 0); // C6
            p.WriteInt(0x00);
            p.WriteInt(0x00); //red?
            p.WriteInt(0x01);
            p.WriteInt(0x01);
            p.WriteInt(_npc.AbnormalBitMaskEx);
            p.WriteInt(0x00); //freya
        }
    }
}