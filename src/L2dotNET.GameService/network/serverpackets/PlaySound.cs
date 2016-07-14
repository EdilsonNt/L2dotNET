namespace L2dotNET.GameService.Network.Serverpackets
{
    class PlaySound
    {
        private readonly string _file;
        private readonly int _type;
        private const uint X = 0;
        private const uint Y = 0;
        private const uint Z = 0;

        public PlaySound(string file, bool ogg = false)
        {
            _file = file;

            if (ogg)
            {
                _type = 1;
            }
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x9e);
            p.WriteInt(_type);
            p.WriteString(_file);
            p.WriteInt(0);
            p.WriteInt(0);
            p.WriteInt(X);
            p.WriteInt(Y);
            p.WriteInt(Z);
        }
    }
}