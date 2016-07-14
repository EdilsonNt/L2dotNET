using System.Collections.Generic;
using L2dotNET.GameService.Model.Communities;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeShowMemberListAll
    {
        private readonly L2Clan _clan;
        private readonly EClanType _type;

        public PledgeShowMemberListAll(L2Clan clan, EClanType type)
        {
            _clan = clan;
            _type = type;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x5a);

            p.WriteInt((short)_type == 0 ? 0 : 1);
            p.WriteInt(_clan.ClanId);
            p.WriteInt((short)_type);
            p.WriteString(_clan.Name);
            p.WriteString(_clan.ClanMasterName);

            p.WriteInt(_clan.CrestId);
            p.WriteInt(_clan.Level);
            p.WriteInt(_clan.CastleId);
            p.WriteInt(_clan.HideoutId);
            p.WriteInt(_clan.FortressId);
            p.WriteInt(_clan.ClanRank);
            p.WriteInt(_clan.ClanNameValue);
            p.WriteInt(_clan.Status);
            p.WriteInt(_clan.Guilty);
            p.WriteInt(_clan.AllianceId);
            p.WriteString(_clan.AllianceName);
            p.WriteInt(_clan.AllianceCrestId);
            p.WriteInt(_clan.InWar);
            p.WriteInt(_clan.JoinDominionWarId);
            List<ClanMember> members = _clan.GetClanMembers(_type, 0);
            p.WriteInt(members.Count);

            foreach (ClanMember m in members)
            {
                p.WriteString(m.Name);
                p.WriteInt(m.Level);
                p.WriteInt(m.ClassId);
                p.WriteInt(m.Gender);
                p.WriteInt(m.Race);
                p.WriteInt(m.OnlineId()); // 1=online 0=offline
                p.WriteInt(m.HaveMaster()); //c5 makes the name yellow. member is in academy and has a sponsor
            }
        }
    }
}