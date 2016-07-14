using L2dotNET.GameService.Controllers;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ClientSetTime
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0xEC);
            p.WriteInt(GameTime.Instance.Time);
            p.WriteInt(6);
        }
    }
}