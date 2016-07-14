using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PartySmallWindowAll
    {
        private readonly L2Party _party;

        public PartySmallWindowAll(L2Party party)
        {
            _party = party;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x4e);
            p.WriteInt(_party.Leader.ObjId);
            p.WriteInt(_party.ItemDistribution);
            p.WriteInt(_party.Members.Count);

            foreach (L2Player member in _party.Members)
            {
                p.WriteInt(member.ObjId);
                p.WriteString(member.Name);

                p.WriteInt(member.CurCp);
                p.WriteInt(member.CharacterStat.GetStat(EffectType.BMaxCp));
                p.WriteInt(member.CurHp);
                p.WriteInt(member.CharacterStat.GetStat(EffectType.BMaxHp));
                p.WriteInt(member.CurMp);
                p.WriteInt(member.CharacterStat.GetStat(EffectType.BMaxMp));
                p.WriteInt(member.Level);

                p.WriteInt((int)member.ActiveClass.ClassId.Id);
                p.WriteInt(0x00); // p.WriteInt(0x01); ??
                p.WriteInt((int)member.BaseClass.ClassId.ClassRace);
            }
        }
    }
}