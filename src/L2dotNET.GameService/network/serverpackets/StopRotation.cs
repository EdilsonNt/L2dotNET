namespace L2dotNET.GameService.Network.Serverpackets
{
    class StopRotation
    {
        private readonly int _sId;
        private readonly int _degree;
        private readonly int _speed;

        public StopRotation(int sId, int degree, int speed)
        {
            _sId = sId;
            _degree = degree;
            _speed = speed;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x63);
            p.WriteInt(_sId);
            p.WriteInt(_degree);
            p.WriteInt(_speed);
            p.WriteInt(_degree);
        }
    }
}