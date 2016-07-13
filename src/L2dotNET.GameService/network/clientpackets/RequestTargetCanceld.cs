using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestTargetCanceld : PacketBase
    {
        public RequestTargetCanceld(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        private short _unselect;

        public override void Read()
        {
            _unselect = ReadH(); //0 esc key, 1 - mouse
        }

        public override void RunImpl()
        {
            L2Player player = GetClient().CurrentPlayer;

            if ((_unselect == 0) && player.IsCastingNow())
            {
                player.AbortCast();
                return;
            }

            if (player.CurrentTarget != null)
            {
                player.ChangeTarget();
            }
        }
    }
}