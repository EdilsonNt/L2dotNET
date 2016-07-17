using L2dotNET.GameService.Model.Vehicles;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class VehicleInfo
    {
        private const byte Opcode = 0x59;

        internal static Packet ToPacket(L2Boat boat)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(boat.ObjId);
            p.WriteInt(boat.X);
            p.WriteInt(boat.Y);
            p.WriteInt(boat.Z);
            p.WriteInt(boat.Heading);
            return p;
        }
    }
}