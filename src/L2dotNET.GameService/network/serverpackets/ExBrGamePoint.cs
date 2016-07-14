namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExBrGamePoint
    {
        private readonly int _id;
        private readonly long _points;

        public ExBrGamePoint(int id, long points)
        {
            _id = id;
            _points = points;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0xC9);

            p.WriteInt(_id);
            p.WriteInt(_points);
            p.WriteInt(0);
        }
    }
}