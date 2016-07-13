using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestDominionInfo : PacketBase
    {
        public RequestDominionInfo(Packet packet, GameClient client)
        {
            Makeme(client, data, 2);
        }

        public override void Read()
        {
            //nothing
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            player.SendPacket(new ExReplyDominionInfo());
            player.SendPacket(new ExShowOwnthingPos());
        }
    }
}