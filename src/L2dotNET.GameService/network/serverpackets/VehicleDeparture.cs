using L2dotNET.GameService.Model.Vehicles;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class VehicleDeparture
    {
        private const byte Opcode = 0x5A;

        internal static Packet ToPacket(L2Boat boat, int speed, int rotationSpd)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(boat.ObjId);
            p.WriteInt(speed);
            p.WriteInt(rotationSpd);
            p.WriteInt(boat.DestX);
            p.WriteInt(boat.DestY);
            p.WriteInt(boat.DestZ);
            return p;
        }
    }
}