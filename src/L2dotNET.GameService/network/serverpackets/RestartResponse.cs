using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class RestartResponse
    {
        private const byte Opcode = 0x5f;

        internal static Packet ToPacket(bool result)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0x01);
            return p;
        }
    }
}