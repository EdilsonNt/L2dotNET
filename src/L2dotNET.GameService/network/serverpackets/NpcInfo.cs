using L2dotNET.GameService.Model.Npcs;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class NpcInfo
    {
        private const byte Opcode = 0x16;

        internal static Packet ToPacket(L2Npc npc)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(npc.ObjId);
            p.WriteInt(npc.NpcHashId);
            p.WriteInt(npc.Attackable);
            p.WriteInt(npc.X);
            p.WriteInt(npc.Y);
            p.WriteInt(npc.Z);
            p.WriteInt(npc.Heading);
            p.WriteInt(0x00);

            double spd = npc.CharacterStat.GetStat(EffectType.PSpeed);
            double atkspd = npc.CharacterStat.GetStat(EffectType.BAttackSpd);
            double cast = npc.CharacterStat.GetStat(EffectType.BCastingSpd);
            double anim = (spd * 1f) / 120;
            double anim2 = (1.1 * atkspd) / 277;

            p.WriteInt((int)cast);
            p.WriteInt((int)atkspd);
            p.WriteInt((int)spd); //run speed
            p.WriteInt((int)(spd * .8));// walk speed
            p.WriteInt((int)spd); // swimspeed
            p.WriteInt((int)(spd * .8)); // swimspeed
            p.WriteInt((int)spd);
            p.WriteInt((int)(spd * .8));
            p.WriteInt((int)spd);
            p.WriteInt((int)(spd * .8));

            p.WriteDouble(anim);
            p.WriteDouble(anim2);
            p.WriteDouble(npc.Radius);
            p.WriteDouble(npc.Height);
            p.WriteInt(npc.Template.RHand); // right hand weapon
            p.WriteInt(0);//chest??
            p.WriteInt(npc.Template.LHand); // left hand weapon
            p.WriteByte(1); // name above char 1=true ... ??
            p.WriteByte(npc.isRunning());
            p.WriteByte(npc.isInCombat() ? (byte)1 : (byte)0);
            p.WriteByte(npc.IsAlikeDead());
            p.WriteByte(npc.Summoned ? (byte)2 : (byte)0); // invisible ?? 0=false  1=true   2=summoned (only works if model has a summon animation)
            p.WriteString(npc.Name);
            p.WriteString(npc.Template.Title);
            p.WriteInt(0x00); // Title color 0=client default
            p.WriteInt(0x00); //pvp flag
            p.WriteInt(0x00); // karma

            p.WriteInt(npc.AbnormalBitMask);
            p.WriteInt(npc.ClanId);
            p.WriteInt(npc.ClanCrestId);
            p.WriteInt(npc.AllianceId);
            p.WriteInt(npc.AllianceCrestId);

            p.WriteByte(npc.IsFlying() ? (byte)2 : (byte)0); // C2
            p.WriteByte(0);// teamId??

            p.WriteDouble(npc.Template.CollisionRadius);
            p.WriteDouble(npc.Template.CollisionHeight);
            p.WriteInt(0); // enchant
            p.WriteInt(npc.IsFlying() ? 1 : 0); // C6

            return p;
        }
    }
}