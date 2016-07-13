using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class CannotMoveAnymore : PacketBase
    {
        private int _x;
        private int _y;
        private int _z;
        private int _heading;

        public CannotMoveAnymore(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        public override void Read()
        {
            _x = ReadD();
            _y = ReadD();
            _z = ReadD();
            _heading = ReadD();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            player.NotifyStopMove(true, true);
        }
    }
}