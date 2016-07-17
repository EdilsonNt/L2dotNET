using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class StartRotation
    {
        private const byte Opcode = 0x62;

        internal static Packet ToPacket(int sId, int degree, int side, int speed)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(sId);
            p.WriteInt(degree);
            p.WriteInt(side);
            p.WriteInt(speed);
            return p;
        }
    }
}