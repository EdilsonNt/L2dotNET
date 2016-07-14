namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExChangePostState
    {
        private readonly bool _receivedBoard;
        private readonly int[] _msgs;
        private readonly int _status;
        public static int Deleted = 0;
        public static int Readed = 1;
        public static int Rejected = 2;

        public ExChangePostState(bool p, int msgId, int status)
        {
            _receivedBoard = p;
            _msgs = new[] { msgId };
            _status = status;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0xb3);
            p.WriteInt(_receivedBoard ? 1 : 0);
            p.WriteInt(_msgs.Length);
            foreach (int postId in _msgs)
            {
                p.WriteInt(postId);
                p.WriteInt(_status);
            }
        }
    }
}