using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets.ClanAPI
{
    class RequestWithdrawalPledge : PacketBase
    {
        public RequestWithdrawalPledge(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        public override void Read()
        {
            // not actions
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            if (player.Clan != null)
            {
                player.Clan.Leave(player);
            }
            else
            {
                player.SendActionFailed();
            }
        }
    }
}