using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets.PartyAPI
{
    class AnswerPartyLootModification : PacketBase
    {
        private byte _answer;

        public AnswerPartyLootModification(Packet packet, GameClient client)
        {
            Makeme(client, data, 2);
        }

        public override void Read()
        {
            _answer = (byte)ReadD();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            if (player.Party == null)
            {
                player.SendActionFailed();
                return;
            }

            player.Party.AnswerLootVote(player, _answer);
        }
    }
}