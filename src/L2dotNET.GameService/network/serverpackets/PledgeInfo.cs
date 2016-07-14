namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeInfo
    {
        private readonly int _id;
        private readonly string _name;
        private readonly string _ally;

        public PledgeInfo(int id, string name, string ally)
        {
            _id = id;
            _name = name;
            _ally = ally;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x89);
            p.WriteInt(_id);
            p.WriteString(_name);
            p.WriteString(_ally);
        }
    }
}