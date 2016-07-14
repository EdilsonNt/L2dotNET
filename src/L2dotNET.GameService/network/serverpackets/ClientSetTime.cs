using L2dotNET.GameService.Controllers;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ClientSetTime
    {
        private const byte Opcode = 0xEC;

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(GameTime.Instance.Time);
            p.WriteInt(6);
            return p;
        }
    }
}