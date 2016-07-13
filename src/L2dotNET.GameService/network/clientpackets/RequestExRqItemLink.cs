using L2dotNET.GameService.Config;
using L2dotNET.GameService.Managers;
using L2dotNET.GameService.Model.Items;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestExRqItemLink : PacketBase
    {
        private int _objectId;

        public RequestExRqItemLink(Packet packet, GameClient client)
        {
            Makeme(client, data, 2);
        }

        public override void Read()
        {
            _objectId = packet.ReadInt();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            L2Item item = RqItemManager.GetInstance().GetItem(_objectId);
            if (item == null)
            {
                player.SendMessage("That item was deleted or modifyed.");
            }
            else
            {
                player.SendPacket(new ExRpItemLink(item));
            }
        }
    }
}