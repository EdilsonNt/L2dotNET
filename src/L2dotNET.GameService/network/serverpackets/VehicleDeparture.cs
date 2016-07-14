using L2dotNET.GameService.Model.Vehicles;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class VehicleDeparture
    {
        private readonly L2Boat _boat;
        private readonly int _speed;
        private readonly int _rotationSpd;

        public VehicleDeparture(L2Boat boat, int speed, int rotationSpd)
        {
            _boat = boat;
            _speed = speed;
            _rotationSpd = rotationSpd;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x5A);
            p.WriteInt(_boat.ObjId);
            p.WriteInt(_speed);
            p.WriteInt(_rotationSpd);
            p.WriteInt(_boat.DestX);
            p.WriteInt(_boat.DestY);
            p.WriteInt(_boat.DestZ);
        }
    }
}