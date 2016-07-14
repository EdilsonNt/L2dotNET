namespace L2dotNET.GameService.Network.Serverpackets
{
    public class ShowTownMap
    {
        private readonly string _texture;
        private readonly int _x;
        private readonly int _y;

        public ShowTownMap(string texture, int x, int y)
        {
            _texture = texture;
            _x = x;
            _y = y;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xde);
            p.WriteString(_texture);
            p.WriteInt(_x);
            p.WriteInt(_y);
        }
    }
}