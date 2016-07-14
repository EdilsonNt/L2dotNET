namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeShowMemberListDeleteAll
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0x88);
        }
    }
}