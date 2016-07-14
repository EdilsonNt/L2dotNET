using L2dotNET.GameService.Model.Playable;
using L2dotNET.GameService.Model.Skills2;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExPartyPetWindowAdd
    {
        private readonly L2Summon _summon;

        public ExPartyPetWindowAdd(L2Summon summon)
        {
            _summon = summon;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x18);
            p.WriteInt(_summon.ObjId);
            p.WriteInt(_summon.Template.NpcId + 1000000);
            p.WriteInt(_summon.ObjectSummonType);
            p.WriteInt(_summon.Owner.ObjId);
            p.WriteString(_summon.Name);
            p.WriteInt(_summon.CurHp);
            p.WriteInt(_summon.CharacterStat.GetStat(EffectType.BMaxHp));
            p.WriteInt(_summon.CurMp);
            p.WriteInt(_summon.CharacterStat.GetStat(EffectType.BMaxMp));
            p.WriteInt(_summon.Level);
        }
    }
}