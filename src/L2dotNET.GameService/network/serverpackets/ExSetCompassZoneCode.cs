using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExSetCompassZoneCode
    {
        public static int Alteredzone = 0x08;
        public static int Siegewarzone1 = 0x0A;
        public static int Siegewarzone2 = 0x0B;
        public static int Peacezone = 0x0C;
        public static int Sevensignszone = 0x0D;
        public static int Pvpzone = 0x0E;
        public static int Generalzone = 0x0F;

        private const short Opcode = 0x33;

        internal static Packet ToPacket(int type)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(type);
            return p;
        }
    }
}