using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class StartRotating : PacketBase
    {
        private int _degree;
        private int _side;

        public StartRotating(Packet packet, GameClient client)
        {
            _client = client;
        }

        public override void Read()
        {
            _degree = packet.ReadInt();
            _side = packet.ReadInt();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            player.BroadcastPacket(new StartRotation(player.ObjId, _degree, _side, 0));
        }
    }
}