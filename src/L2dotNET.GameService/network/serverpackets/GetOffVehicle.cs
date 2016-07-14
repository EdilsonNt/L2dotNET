using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class GetOffVehicle
    {
        private const byte Opcode = 0x5D;

        internal static Packet ToPacket(L2Player player, int x, int y, int z)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(player.ObjId);
            p.WriteInt(player.Boat.ObjId);
            p.WriteInt(x);
            p.WriteInt(y);
            p.WriteInt(z);
            return p;
        }
    }
}