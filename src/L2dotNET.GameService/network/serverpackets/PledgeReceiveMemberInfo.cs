using L2dotNET.GameService.Model.Communities;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeReceiveMemberInfo
    {
        private const byte Opcode = 0x3d;

        internal static Packet ToPacket(ClanMember member)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);

            p.WriteInt(member.ClanType);
            p.WriteString(member.Name);
            p.WriteString(member.NickName);
            p.WriteInt(member.ClanPrivs);
            p.WriteString(member.PledgeTypeName);
            p.WriteString(member.OwnerName); // name of this member's apprentice/sponsor
            return p;
        }
    }
}