using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ChangeWaitType
    {
        private const byte Opcode = 0x2f;

        internal static Packet ToPacket(L2Player player, int type)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(player.ObjId);
            p.WriteInt(type);
            p.WriteInt(player.X);
            p.WriteInt(player.Y);
            p.WriteInt(player.Z);
            return p;
        }
    }
}