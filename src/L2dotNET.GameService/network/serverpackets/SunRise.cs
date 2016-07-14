namespace L2dotNET.GameService.Network.Serverpackets
{
    class SunRise
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0x1c);
        }
    }
}