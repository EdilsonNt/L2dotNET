namespace L2dotNET.GameService.Network.Serverpackets
{
    class PartySmallWindowDelete
    {
        private readonly int _id;
        private readonly string _name;

        public PartySmallWindowDelete(int id, string name)
        {
            _id = id;
            _name = name;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x51);
            p.WriteInt(_id);
            p.WriteString(_name);
        }
    }
}