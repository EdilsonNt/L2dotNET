namespace L2dotNET.GameService.Network.Serverpackets
{
    class VehicleStarted
    {
        private readonly int _sId;
        private readonly int _type;

        public VehicleStarted(int sId, int type)
        {
            _sId = sId;
            _type = type;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xBA);
            p.WriteInt(_sId);
            p.WriteInt(_type);
        }
    }
}