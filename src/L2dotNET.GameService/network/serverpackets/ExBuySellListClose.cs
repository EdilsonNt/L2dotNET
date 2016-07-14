namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExBuySellListClose
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0xB7);
            p.WriteInt(1);
            p.WriteShort(0);
            p.WriteShort(0);
            p.WriteInt(1);
        }
    }
}