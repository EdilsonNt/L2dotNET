namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharCreateOk
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0x19);
            p.WriteInt(0x01);
        }
    }
}