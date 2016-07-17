using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SetupGauge
    {
        public enum SgColor
        {
            Blue = 0,
            Red = 1,
            Cyan = 2,
            Green = 3
        }

        private const byte Opcode = 0x6d;

        internal static Packet ToPacket(SgColor color, int time)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt((int)color);
            p.WriteInt(time);
            p.WriteInt(time); //c2
            return p;
        }
    }
}