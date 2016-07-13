using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets.VehicleAPI
{
    class RequestGetOffVehicle : PacketBase
    {
        private int _boatId;
        private int _x;
        private int _y;
        private int _z;

        public RequestGetOffVehicle(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        public override void Read()
        {
            _boatId = ReadD();
            _x = ReadD();
            _y = ReadD();
            _z = ReadD();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            if ((player.Boat == null) || (player.Boat.ObjId != _boatId))
            {
                player.SendActionFailed();
                return;
            }

            if (player.Boat.OnRoute)
            {
                player.SendActionFailed();
                return;
            }

            player.BroadcastPacket(new StopMoveInVehicle(player, _x, _y, _z));
            player.BroadcastPacket(new GetOffVehicle(player, _x, _y, _z));
            player.Boat = null;
        }
    }
}