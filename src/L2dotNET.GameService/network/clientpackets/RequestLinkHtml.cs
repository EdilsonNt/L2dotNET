using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestLinkHtml : PacketBase
    {
        public RequestLinkHtml(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        private string _link;

        public override void Read()
        {
            _link = ReadS();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            // log.Info($"link to '{ _link }'");

            string file;
            int id = 0;
            if (_link.Contains("#"))
            {
                file = _link.Split('#')[0];
                id = int.Parse(_link.Split('#')[1]);
            }
            else
            {
                file = _link;
            }

            int idx = player.CurrentTarget?.ObjId ?? player.ObjId;

            player.SendPacket(new NpcHtmlMessage(player, file, idx, id));
        }
    }
}