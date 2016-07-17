using L2dotNET.Network;

namespace L2dotNET.GameService.Network.LoginAuth.Send
{
    class LoginAuth
    {
        private const byte Opcode = 0xA1;

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteShort((short)Config.Config.Instance.ServerConfig.Port);
            p.WriteString(Config.Config.Instance.ServerConfig.Host);
            p.WriteString("");
            p.WriteString(Config.Config.Instance.ServerConfig.AuthCode);
            p.WriteInt(0);
            p.WriteShort((short)Config.Config.Instance.ServerConfig.MaxPlayers);
            p.WriteByte(Config.Config.Instance.ServerConfig.IsGmOnly ? (byte)0x01 : (byte)0x00);
            p.WriteByte(Config.Config.Instance.ServerConfig.IsTestServer ? (byte)0x01 : (byte)0x00);
            return p;
        }
    }
}