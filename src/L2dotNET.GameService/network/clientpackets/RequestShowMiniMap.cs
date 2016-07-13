using L2dotNET.GameService.Config;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestShowMiniMap : PacketBase
    {
        public RequestShowMiniMap(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        public override void Read()
        {
            // do nothing
        }

        public override void RunImpl()
        {
            Client.SendPacket(new ShowMiniMap());
        }
    }
}