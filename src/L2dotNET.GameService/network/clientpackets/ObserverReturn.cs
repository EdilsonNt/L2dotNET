using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class ObserverReturn : PacketBase
    {
        public ObserverReturn(Packet packet, GameClient client)
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

            player.SendPacket(new ObservationReturn(player.Obsx, player.Obsy, player.Obsz));
        }
    }
}