namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExSetPartyLooting
    {
        private readonly int _result;
        private readonly int _mode;

        public ExSetPartyLooting(short voteId)
        {
            if (voteId == -1)
            {
                return;
            }

            _result = 1;
            _mode = voteId;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0xBF);
            p.WriteInt(_result);
            p.WriteInt(_mode);
        }
    }
}