namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExNoticePostSent
    {
        private readonly int _anim;

        public ExNoticePostSent(int anim)
        {
            _anim = anim;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0xb4);
            p.WriteInt(_anim);
        }
    }
}