namespace L2dotNET.GameService.Network.Serverpackets
{
    class SocialAction
    {
        private readonly int _social;
        private readonly int _id;

        public SocialAction(int id, int social)
        {
            _social = social;
            _id = id;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x2d);
            p.WriteInt(_id);
            p.WriteInt(_social);
        }
    }
}