using L2dotNET.Network;

namespace L2dotNET.GameService.Network.LoginAuth.Send
{
    class PlayerCount
    {
        private const byte Opcode = 0xA3;

        internal static Packet ToPacket(short cnt)
        {
            Packet p = new Packet(Opcode);
            p.WriteShort(cnt);
            return p;
        }
    }
}