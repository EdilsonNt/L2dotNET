using L2dotNET.Network;

namespace L2dotNET.GameService.Network.LoginAuth.Send
{
    class AccountInGame
    {
        private const byte Opcode = 0x03;

        internal static Packet ToPacket(string account, bool status)
        {
            Packet p = new Packet(Opcode);
            p.WriteString(account.ToLower());
            p.WriteByte(status ? (byte)1 : (byte)0);
            return p;
        }
    }
}