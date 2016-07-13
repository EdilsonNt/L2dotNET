using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestItemList : PacketBase
    {
        public RequestItemList(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        public override void Read()
        {
            // do nothing
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;
            player.SendItemList(true);
        }
    }
}