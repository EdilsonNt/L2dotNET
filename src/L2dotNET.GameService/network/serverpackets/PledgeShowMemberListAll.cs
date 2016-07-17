using System.Collections.Generic;
using L2dotNET.GameService.Model.Communities;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeShowMemberListAll
    {
        private const byte Opcode = 0x53;

        internal static Packet ToPacket(L2Clan clan, EClanType type)
        {
            Packet p = new Packet(Opcode);

            p.WriteInt((short)type == 0 ? 0 : 1);
            p.WriteInt(clan.ClanId);
            p.WriteInt((short)type);
            p.WriteString(clan.Name);
            p.WriteString(clan.ClanMasterName);

            p.WriteInt(clan.CrestId);
            p.WriteInt(clan.Level);
            p.WriteInt(clan.CastleId);
            p.WriteInt(clan.HideoutId);
            p.WriteInt(clan.FortressId);
            p.WriteInt(clan.ClanRank);
            p.WriteInt(clan.ClanNameValue);
            p.WriteInt(clan.Status);
            p.WriteInt(clan.Guilty);
            p.WriteInt(clan.AllianceId);
            p.WriteString(clan.AllianceName);
            p.WriteInt(clan.AllianceCrestId);
            p.WriteInt(clan.InWar);
            List<ClanMember> members = clan.GetClanMembers(type, 0);
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
            return p;
        }
    }
}