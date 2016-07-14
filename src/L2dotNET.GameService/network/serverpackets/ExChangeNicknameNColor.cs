namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExChangeNicknameNColor
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0x83);
        }
    }
}