using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets.PartyAPI
{
    class RequestPartyLootModification : PacketBase
    {
        private byte _mode;

        public RequestPartyLootModification(Packet packet, GameClient client)
        {
            Makeme(client, data, 2);
        }

        public override void Read()
        {
            _mode = (byte)ReadD();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            if (player.Party == null)
            {
                player.SendActionFailed();
                return;
            }

            if ((_mode < player.Party.ItemLooter) || (_mode > player.Party.ItemOrderSpoil) || (_mode == player.Party.ItemDistribution) || (player.Party.Leader.ObjId != player.ObjId))
            {
                player.SendActionFailed();
                return;
            }

            player.Party.VoteForLootChange(_mode);
        }
    }
}