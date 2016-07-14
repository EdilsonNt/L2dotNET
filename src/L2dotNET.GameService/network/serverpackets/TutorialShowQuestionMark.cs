namespace L2dotNET.GameService.Network.Serverpackets
{
    class TutorialShowQuestionMark
    {
        private readonly int _questionId;

        public TutorialShowQuestionMark(int id)
        {
            _questionId = id;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xa1);
            p.WriteInt(_questionId);
        }
    }
}