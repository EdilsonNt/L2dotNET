using L2dotNET.GameService.Model.Communities;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeReceiveMemberInfo
    {
        private readonly ClanMember _member;

        public PledgeReceiveMemberInfo(ClanMember cm)
        {
            _member = cm;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x3e);

            p.WriteInt(_member.ClanType);
            p.WriteString(_member.Name);
            p.WriteString(_member.NickName);
            p.WriteInt(_member.ClanPrivs);
            p.WriteString(_member.PledgeTypeName);
            p.WriteString(_member.OwnerName); // name of this member's apprentice/sponsor
        }
    }
}