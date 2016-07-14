using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    static class AutoAttackStart
    {
        private const byte Opcode = 0x2b;

        internal static Packet ToPacket(int sId)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(sId);
            return p;
        }
    }
}