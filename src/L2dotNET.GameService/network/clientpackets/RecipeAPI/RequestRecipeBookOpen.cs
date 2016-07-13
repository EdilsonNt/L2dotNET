using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets.RecipeAPI
{
    class RequestRecipeBookOpen : PacketBase
    {
        public RequestRecipeBookOpen(Packet packet, GameClient client)
        {
            _client = client;
        }

        private int _type;

        public override void Read()
        {
            _type = packet.ReadInt();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            player.SendPacket(new RecipeBookItemList(player, _type));
        }
    }
}