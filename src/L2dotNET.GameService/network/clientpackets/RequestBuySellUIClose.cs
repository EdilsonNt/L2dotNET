using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestBuySellUiClose : PacketBase
    {
        public RequestBuySellUiClose(Packet packet, GameClient client)
        {
            Makeme(client, data, 2);
        }

        public override void Read()
        {
            // nothing
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            player.SendItemList(true);
        }
    }
}