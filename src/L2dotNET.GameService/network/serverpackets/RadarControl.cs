using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class RadarControl
    {
        private const byte Opcode = 0xEB;

        internal static Packet ToPacket(int showRadar, int type, int x, int y, int z)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(showRadar); // 0 = showradar; 1 = delete radar;
            p.WriteInt(type);
            p.WriteInt(x);
            p.WriteInt(y);
            p.WriteInt(z);
            return p;
        }
    }
}