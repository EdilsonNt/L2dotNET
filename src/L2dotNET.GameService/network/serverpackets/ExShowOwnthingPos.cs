namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExShowOwnthingPos
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x93);

            p.WriteInt(0);
            p.WriteInt(0);
        }
    }
}