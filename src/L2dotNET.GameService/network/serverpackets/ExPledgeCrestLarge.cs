namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExPledgeCrestLarge
    {
        private readonly int _id;
        private readonly byte[] _picture;

        public ExPledgeCrestLarge(int id, byte[] picture)
        {
            _id = id;
            if (picture == null)
            {
                picture = new byte[0];
            }

            _picture = picture;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x1b);

            p.WriteInt(0x00); //???
            p.WriteInt(_id);
            p.WriteInt(_picture.Length);
            WriteB(_picture);
        }
    }
}