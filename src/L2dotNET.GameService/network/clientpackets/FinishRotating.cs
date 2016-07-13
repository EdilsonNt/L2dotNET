using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class FinishRotating : PacketBase
    {
        private int _degree;

        public FinishRotating(Packet packet, GameClient client)
        {
            _client = client;
        }

        public override void Read()
        {
            _degree = packet.ReadInt();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            player.BroadcastPacket(new StopRotation(player.ObjId, _degree, 0));
        }
    }
}