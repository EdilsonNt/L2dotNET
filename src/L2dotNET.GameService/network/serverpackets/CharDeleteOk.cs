namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharDeleteOk
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0x23);
        }
    }
}