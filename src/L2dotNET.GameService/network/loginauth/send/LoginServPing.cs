using L2dotNET.Network;

namespace L2dotNET.GameService.Network.LoginAuth.Send
{
    class LoginServPing
    {
        private const byte Opcode = 0xA0;

        internal static Packet ToPacket(AuthThread th)
        {
            Packet p = new Packet(Opcode);
            p.WriteString(th.Version);
            p.WriteInt(th.Build);
            return p;
        }
    }
}