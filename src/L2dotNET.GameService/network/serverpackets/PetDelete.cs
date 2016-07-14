namespace L2dotNET.GameService.Network.Serverpackets
{
    class PetDelete
    {
        private readonly byte _objectSummonType;
        private readonly int _objId;

        public PetDelete(byte objectSummonType, int objId)
        {
            _objectSummonType = objectSummonType;
            _objId = objId;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xb6);
            p.WriteInt(_objectSummonType);
            p.WriteInt(_objId);
        }
    }
}