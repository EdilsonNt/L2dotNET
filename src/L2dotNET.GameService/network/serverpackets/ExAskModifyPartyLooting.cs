namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExAskModifyPartyLooting
    {
        private readonly string _leader;
        private readonly byte _mode;

        public ExAskModifyPartyLooting(string leader, byte mode)
        {
            _leader = leader;
            _mode = mode;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0xBE);
            p.WriteString(_leader);
            p.WriteInt(_mode);
        }
    }
}