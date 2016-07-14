namespace L2dotNET.GameService.Network.Serverpackets
{
    class SunSet
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0x1d);
        }
    }
}