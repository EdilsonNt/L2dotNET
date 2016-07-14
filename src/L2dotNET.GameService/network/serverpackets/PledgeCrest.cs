namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeCrest
    {
        private readonly int _id;
        private readonly byte[] _picture;

        public PledgeCrest(int id, byte[] picture)
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
            p.WriteInt(0x6a);
            p.WriteInt(_id);
            p.WriteInt(_picture.Length);
            WriteB(_picture);
        }
    }
}