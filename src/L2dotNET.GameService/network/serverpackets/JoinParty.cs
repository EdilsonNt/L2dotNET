using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class JoinParty
    {
        private const byte Opcode = 0x3a;

        internal static Packet ToPacket(int response)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(response);
            return p;
        }
    }
}