using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class DeleteObject
    {
        private const byte Opcode = 0x12;

        internal static Packet ToPacket(int id)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(id);
            p.WriteInt(0);
            return p;
        }
    }
}