using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class AutoAttackStop
    {
        private readonly int _sId;

        public AutoAttackStop(int sId)
        {
            _sId = sId;
        }

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0x2c);
            p.WriteInt(_sId);
        }
    }
}