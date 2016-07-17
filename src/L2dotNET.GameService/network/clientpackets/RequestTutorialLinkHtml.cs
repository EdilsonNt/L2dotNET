using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;
using L2dotNET.Utility;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestTutorialLinkHtml : PacketBase
    {
        private string _link;
        private readonly GameClient _client;

        public RequestTutorialLinkHtml(Packet packet, GameClient client)
        {
            _client = client;
            _link = packet.ReadString();
        }

        public override void RunImpl()
        {
            L2Player player = _client.CurrentPlayer;

            if (_link.Contains(":"))
            {
                string[] link = _link.Split(':');
                player.SendPacket(TutorialShowHtml.ToPacket(_link));
            }
            else if (_link.StartsWithIgnoreCase("tutorial_close_"))
            {
                player.SendPacket(TutorialCloseHtml.ToPacket());
            }
            else if (_link.EqualsIgnoreCase("admin_close"))
            {
                player.SendPacket(TutorialCloseHtml.ToPacket());
                player.ViewingAdminPage = 0;
                player.ViewingAdminTeleportGroup = -1;
            }
            else
            {
                player.SendPacket(TutorialShowHtml.ToPacket(_link));
            }
        }
    }
}