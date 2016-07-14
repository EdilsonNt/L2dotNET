namespace L2dotNET.GameService.Network.Serverpackets
{
    class LeaveWorld
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0x7e);
        }
    }
}