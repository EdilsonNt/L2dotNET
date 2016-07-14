using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExBrGamePoint
    {
        private const short Opcode = 0xC9;

        internal static Packet ToPacket(int id, int points)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);

            p.WriteInt(id);
            p.WriteInt(points);
            p.WriteInt(0);
            return p;
        }
    }
}