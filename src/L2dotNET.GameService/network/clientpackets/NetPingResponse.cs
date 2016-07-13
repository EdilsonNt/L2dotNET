using L2dotNET.GameService.Config;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class NetPingResponse : PacketBase
    {
        private int _request;
        private int _msec;
        private int _unk2;

        public NetPingResponse(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        public override void Read()
        {
            _request = ReadD();
            _msec = ReadD();
            _unk2 = ReadD();
        }

        public override void RunImpl()
        {
            Client.CurrentPlayer.UpdatePing(_request, _msec, _unk2);
        }
    }
}