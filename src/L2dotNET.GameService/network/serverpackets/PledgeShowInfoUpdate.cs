using L2dotNET.GameService.Model.Communities;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeShowInfoUpdate
    {
        private const byte Opcode = 0x88;

        internal static Packet ToPacket(L2Clan clan)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(clan.ClanId);
            p.WriteInt(clan.CrestId);
            p.WriteInt(clan.Level);
            p.WriteInt(clan.CastleId);
            p.WriteInt(clan.HideoutId);
            p.WriteInt(clan.ClanRank);
            p.WriteInt(clan.ClanNameValue);
            p.WriteInt(clan.Status);
            p.WriteInt(clan.Guilty);
            p.WriteInt(clan.AllianceId);
            p.WriteString(clan.AllianceName);
            p.WriteInt(clan.AllianceCrestId);
            p.WriteInt(clan.InWar);
            return p;
        }
    }
}