namespace L2dotNET.GameService.Network.Serverpackets
{
    class ShowMiniMap
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0x9d);
            p.WriteInt(1665);
            p.WriteInt(0); //SevenSigns.getInstance().getCurrentPeriod());
        }
    }
}