using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestAction : PacketBase
    {
        public RequestAction(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        private int _serverId;
        private int _x;
        private int _y;
        private int _z;
        private int _actionId;

        public override void Read()
        {
            _serverId = ReadD();
            _x = ReadD();
            _y = ReadD();
            _z = ReadD();
            _actionId = ReadC(); // Action identifier : 0-Simple click, 1-Shift click
        }

        public override void RunImpl()
        {
            L2Player player = GetClient().CurrentPlayer;

            L2Object obj = null;

            if (_serverId == player.ObjId)
            {
                obj = player;
            }
            else
            {
                if (player.KnownObjects.ContainsKey(_serverId))
                {
                    obj = player.KnownObjects[_serverId];
                }
            }

            if (obj == null)
            {
                player.SendActionFailed();
                return;
            }

            switch (_actionId)
            {
                case 0:
                    obj.OnAction(player);
                    break;
                case 1:
                    obj.OnActionShift(player);
                    break;
            }
        }
    }
}