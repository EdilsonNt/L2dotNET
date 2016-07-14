using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class StopMoveInVehicle
    {
        private readonly L2Player _player;
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;

        public StopMoveInVehicle(L2Player player, int x, int y, int z)
        {
            _player = player;
            _x = x;
            _y = y;
            _z = z;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x72);
            p.WriteInt(_player.ObjId);
            p.WriteInt(_player.Boat.ObjId);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
            p.WriteInt(_player.Heading);
        }
    }
}