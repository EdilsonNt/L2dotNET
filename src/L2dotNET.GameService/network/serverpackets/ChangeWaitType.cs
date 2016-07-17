using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ChangeWaitType
    {
        private const byte Opcode = 0x2f;
        public static int Sit = 0;
        public static int Stand = 1;
        public static int Fake = 2;
        public static int FakeStop = 3;
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