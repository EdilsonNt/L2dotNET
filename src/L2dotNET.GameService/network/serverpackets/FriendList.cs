namespace L2dotNET.GameService.Network.Serverpackets
{
    class FriendList
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0xfa);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
        }
    }
}