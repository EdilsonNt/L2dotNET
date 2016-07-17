using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class MoveToLocationInVehicle
    {
        private const byte Opcode = 0x71;

        internal static Packet ToPacket(L2Player player, int x, int y, int z)
        {
            Packet p = new Packet(Opcode);

            p.WriteInt(player.ObjId);
            p.WriteInt(player.Boat.ObjId);
            p.WriteInt(player.BoatX);
            p.WriteInt(player.BoatY);
            p.WriteInt(player.BoatZ);
            p.WriteInt(x);
            p.WriteInt(y);
            p.WriteInt(z);
            return p;
        }
    }
}