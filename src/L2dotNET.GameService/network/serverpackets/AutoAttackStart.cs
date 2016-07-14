using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    static class AutoAttackStart
    {
        private static readonly int _sId;

        public AutoAttackStart(int sId)
        {
            _sId = sId;
        }

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0x2b);
            p.WriteInt(_sId);
            return p;
        }
    }
}