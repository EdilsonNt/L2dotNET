using L2dotNET.GameService.Model.Playable;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExPartyPetWindowAdd
    {
        private const short Opcode = 0x18;

        internal static Packet ToPacket(L2Summon summon)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(summon.ObjId);
            p.WriteInt(summon.Template.NpcId + 1000000);
            p.WriteInt(summon.ObjectSummonType);
            p.WriteInt(summon.Owner.ObjId);
            p.WriteString(summon.Name);
            p.WriteInt((int)summon.CurHp);
            p.WriteInt((int)summon.CharacterStat.GetStat(EffectType.BMaxHp));
            p.WriteInt((int)summon.CurMp);
            p.WriteInt((int)summon.CharacterStat.GetStat(EffectType.BMaxMp));
            p.WriteInt(summon.Level);
            return p;
        }
    }
}