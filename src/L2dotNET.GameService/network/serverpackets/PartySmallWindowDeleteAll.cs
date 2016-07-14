namespace L2dotNET.GameService.Network.Serverpackets
{
    class PartySmallWindowDeleteAll
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0x50);
        }
    }
}