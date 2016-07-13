using L2dotNET.GameService.Config;
using L2dotNET.GameService.Managers.BBS;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestShowBoard : PacketBase
    {
        private int _type;

        public RequestShowBoard(Packet packet, GameClient client)
        {
            _client = client;
        }

        public override void Read()
        {
            _type = packet.ReadInt();
        }

        public override void RunImpl()
        {
            BbsManager.Instance.RequestShow(Client.CurrentPlayer, _type);
        }
    }
}