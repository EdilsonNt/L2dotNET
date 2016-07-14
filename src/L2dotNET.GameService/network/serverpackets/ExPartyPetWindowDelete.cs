namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExPartyPetWindowDelete
    {
        private readonly int _petId;
        private readonly int _playerId;
        private readonly string _petName;

        public ExPartyPetWindowDelete(int petId, int playerId, string petName)
        {
            _petId = petId;
            _playerId = playerId;
            _petName = petName;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x6a);
            p.WriteInt(_petId);
            p.WriteInt(_playerId);
            p.WriteString(_petName);
        }
    }
}