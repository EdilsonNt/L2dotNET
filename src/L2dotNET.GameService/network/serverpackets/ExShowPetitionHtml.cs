namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExShowPetitionHtml
    {
        private readonly string _content;

        public ExShowPetitionHtml(string text)
        {
            _content = text;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0xB1);

            p.WriteInt(0);
            p.WriteInt(0);
            p.WriteString(_content);
        }
    }
}