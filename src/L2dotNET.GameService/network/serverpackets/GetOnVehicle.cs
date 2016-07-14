using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class GetOnVehicle
    {
        private const byte Opcode = 0x5C;

        internal static Packet ToPacket(L2Player player)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(player.ObjId);
            p.WriteInt(player.Boat.ObjId);
            p.WriteInt(player.BoatX);
            p.WriteInt(player.BoatY);
            p.WriteInt(player.BoatZ);
            return p;
        }
    }
}