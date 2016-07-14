using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class GetOnVehicle
    {
        private readonly L2Player _player;

        public GetOnVehicle(L2Player player)
        {
            _player = player;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x5C);
            p.WriteInt(_player.ObjId);
            p.WriteInt(_player.Boat.ObjId);
            p.WriteInt(_player.BoatX);
            p.WriteInt(_player.BoatY);
            p.WriteInt(_player.BoatZ);
        }
    }
}