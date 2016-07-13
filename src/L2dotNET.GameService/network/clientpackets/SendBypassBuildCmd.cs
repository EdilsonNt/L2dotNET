using L2dotNET.GameService.Handlers;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class SendBypassBuildCmd : PacketBase
    {
        public SendBypassBuildCmd(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        private string _alias;

        public override void Read()
        {
            _alias = ReadS();
            _alias = _alias.Trim();
        }

        public override void RunImpl()
        {
            L2Player player = GetClient().CurrentPlayer;

            AdminCommandHandler.Instance.Request(player, _alias);
        }
    }
}