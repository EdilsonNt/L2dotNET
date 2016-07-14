namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExRaidCharacterSelected
    {
        private int _id;

        public ExRaidCharacterSelected(int id)
        {
            _id = id;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0xBA);

            //  p.WriteInt(id);
            //  p.WriteInt(0);
            //  p.WriteInt(0);
        }
    }
}