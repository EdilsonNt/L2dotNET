using L2dotNET.GameService.Model.Vehicles;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class VehicleInfo
    {
        private readonly L2Boat _boat;

        public VehicleInfo(L2Boat boat)
        {
            _boat = boat;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x59);
            p.WriteInt(_boat.ObjId);
            p.WriteInt(_boat.X);
            p.WriteInt(_boat.Y);
            p.WriteInt(_boat.Z);
            p.WriteInt(_boat.Heading);
        }
    }
}