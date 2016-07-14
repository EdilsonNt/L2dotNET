namespace L2dotNET.GameService.Network.Serverpackets
{
    class PetStatusShow
    {
        private readonly byte _objectSummonType;

        public PetStatusShow(byte objectSummonType)
        {
            _objectSummonType = objectSummonType;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xb1);
            p.WriteInt(_objectSummonType);
        }
    }
}