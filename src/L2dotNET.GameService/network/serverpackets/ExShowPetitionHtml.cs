namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExShowPetitionHtml
    {
        private readonly string _content;

        public ExShowPetitionHtml(string text)
        {
            _content = text;
        }

        protected internal override void Write()
        {
            WriteC(0xFE);
            WriteH(0xB1);

            WriteD(0);
            WriteC(0);
            WriteS(_content);
        }
    }
}