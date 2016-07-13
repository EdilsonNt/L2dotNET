using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets.PartyAPI
{
    class RequestWithDrawalParty : PacketBase
    {
        public RequestWithDrawalParty(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        public override void Read()
        {
            // nothing
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            if (player.Party == null)
            {
                player.SendActionFailed();
                return;
            }

            player.Party.Leave(player);
        }
    }
}