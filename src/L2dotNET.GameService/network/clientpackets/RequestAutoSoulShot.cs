using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Items;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestAutoSoulShot : PacketBase
    {
        private int _itemId;
        private int _type;

        public RequestAutoSoulShot(Packet packet, GameClient client)
        {
            Makeme(client, data, 2);
        }

        public override void Read()
        {
            _itemId = packet.ReadInt();
            _type = packet.ReadInt(); //1 - enable
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            L2Item item = player.Inventory.GetItemByItemId(_itemId);
        }
    }
}