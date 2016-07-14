using L2dotNET.GameService.Model.Communities;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeShowInfoUpdate
    {
        private readonly L2Clan _clan;

        public PledgeShowInfoUpdate(L2Clan clan)
        {
            _clan = clan;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x8e);
            p.WriteInt(_clan.ClanId);
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
            p.WriteInt(_clan.LargeCrestId);
            p.WriteInt(_clan.JoinDominionWarId);
        }
    }
}