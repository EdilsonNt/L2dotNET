using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class MoveToLocationInVehicle
    {
        private readonly L2Player _player;
        private readonly int _x;
        private readonly int _y;
        private readonly int _z;

        public MoveToLocationInVehicle(L2Player player, int x, int y, int z)
        {
            _player = player;
            _x = x;
            _y = y;
            _z = z;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x71);

            p.WriteInt(_player.ObjId);
            p.WriteInt(_player.Boat.ObjId);
            p.WriteInt(_player.BoatX);
            p.WriteInt(_player.BoatY);
            p.WriteInt(_player.BoatZ);
            p.WriteInt(_x);
            p.WriteInt(_y);
            p.WriteInt(_z);
        }
    }
}