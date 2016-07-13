using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets.PartyAPI
{
    class RequestOustPartyMember : PacketBase
    {
        private string _name;

        public RequestOustPartyMember(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        public override void Read()
        {
            _name = ReadS();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            if (player.Party == null)
            {
                player.SendActionFailed();
                return;
            }

            if (player.Party.Leader.ObjId != player.ObjId)
            {
                player.SendSystemMessage(SystemMessage.SystemMessageId.FailedToExpelThePartyMember);
                player.SendActionFailed();
                return;
            }

            player.Party.Expel(_name);
        }
    }
}