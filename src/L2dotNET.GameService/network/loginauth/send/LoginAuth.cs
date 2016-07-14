namespace L2dotNET.GameService.Network.LoginAuth.Send
{
    class LoginAuth
    {
        internal static Packet ToPacket()
        {
            p.WriteInt(0xA1);
            p.WriteShort(Config.Config.Instance.ServerConfig.Port);
            p.WriteString(Config.Config.Instance.ServerConfig.Host);
            p.WriteString("");
            p.WriteString(Config.Config.Instance.ServerConfig.AuthCode);
            p.WriteInt(0);
            p.WriteShort(Config.Config.Instance.ServerConfig.MaxPlayers);
            p.WriteInt(Config.Config.Instance.ServerConfig.IsGmOnly ? 0x01 : 0x00);
            p.WriteInt(Config.Config.Instance.ServerConfig.IsTestServer ? 0x01 : 0x00);
        }
    }
}