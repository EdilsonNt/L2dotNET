using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class StopMoveInVehicle
    {
        private const byte Opcode = 0x72;

        internal static Packet ToPacket(L2Player player, int x, int y, int z)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(player.ObjId);
            p.WriteInt(player.Boat.ObjId);
            p.WriteInt(x);
            p.WriteInt(y);
            p.WriteInt(z);
            p.WriteInt(player.Heading);
            return p;
        }
    }
}