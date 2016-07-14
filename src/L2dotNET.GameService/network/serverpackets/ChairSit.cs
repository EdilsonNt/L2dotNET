using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ChairSit
    {
        private readonly int _sId;
        private readonly int _staticId;

        public ChairSit(int sId, int staticId)
        {
            _sId = sId;
            _staticId = staticId;
        }

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0xe1);
            p.WriteInt(_sId);
            p.WriteInt(_staticId);
        }
    }
}