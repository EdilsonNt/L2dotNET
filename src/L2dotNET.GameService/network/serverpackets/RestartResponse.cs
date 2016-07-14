namespace L2dotNET.GameService.Network.Serverpackets
{
    class RestartResponse
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0x5f);
            p.WriteInt(0x01);
        }
    }
}