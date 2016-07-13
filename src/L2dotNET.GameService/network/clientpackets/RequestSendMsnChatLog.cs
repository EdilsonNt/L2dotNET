using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestSendMsnChatLog : PacketBase
    {
        public RequestSendMsnChatLog(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        private string _text,
                       _email;
        private int _type;

        public override void Read()
        {
            _text = ReadS();
            _email = ReadS();
            _type = ReadD();
        }

        public override void RunImpl()
        {
            //            L2Player player = getClient()._player;

            //todo log
        }
    }
}