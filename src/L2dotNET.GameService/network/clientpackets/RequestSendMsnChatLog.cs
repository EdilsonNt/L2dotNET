using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestSendMsnChatLog : PacketBase
    {
        public RequestSendMsnChatLog(Packet packet, GameClient client)
        {
            _client = client;
        }

        private string _text,
                       _email;
        private int _type;

        public override void Read()
        {
            _text = packet.ReadString();
            _email = packet.ReadString();
            _type = packet.ReadInt();
        }

        public override void RunImpl()
        {
            //            L2Player player = getClient()._player;

            //todo log
        }
    }
}