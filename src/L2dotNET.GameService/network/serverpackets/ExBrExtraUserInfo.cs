namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExBrExtraUserInfo
    {
        private readonly int _playerId;
        private readonly int _value;

        public ExBrExtraUserInfo(int id, int value)
        {
            _playerId = id;
            _value = value;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0xcf);
            p.WriteInt(_playerId);
            p.WriteInt(_value); // event effect id
            //p.WriteInt(0x00);		// Event flag, added only if event is active
        }
    }
}