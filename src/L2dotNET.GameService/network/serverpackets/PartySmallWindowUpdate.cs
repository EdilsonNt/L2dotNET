using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PartySmallWindowUpdate
    {
        private readonly L2Player _member;

        public PartySmallWindowUpdate(L2Player member)
        {
            _member = member;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x52);
            p.WriteInt(_member.ObjId);
            p.WriteString(_member.Name);
            p.WriteInt(_member.CurCp);
            p.WriteInt(_member.CharacterStat.GetStat(EffectType.BMaxCp));
            p.WriteInt(_member.CurHp);
            p.WriteInt(_member.CharacterStat.GetStat(EffectType.BMaxHp));
            p.WriteInt(_member.CurMp);
            p.WriteInt(_member.CharacterStat.GetStat(EffectType.BMaxMp));
            p.WriteInt(_member.Level);
            p.WriteInt((int)_member.ActiveClass.ClassId.Id);
        }
    }
}