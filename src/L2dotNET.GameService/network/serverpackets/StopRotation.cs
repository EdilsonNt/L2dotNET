using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class StopRotation
    {
        private const byte Opcode = 0x63;

        internal static Packet ToPacket(int sId, int degree, int speed)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(sId);
            p.WriteInt(degree);
            p.WriteInt(speed);
            p.WriteByte((byte)degree);
            return p;
        }
    }
}