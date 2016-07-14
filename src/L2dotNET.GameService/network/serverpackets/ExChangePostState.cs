using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExChangePostState
    {
        private const short Opcode = 0xb3;
        private static int[] _msgs;

        public static int Deleted = 0;
        public static int Readed = 1;
        public static int Rejected = 2;

        internal static Packet ToPacket(bool receivedBoard, int msgId, int status)
        {
            _msgs = new[] {msgId};
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(receivedBoard ? 1 : 0);
            p.WriteInt(_msgs.Length);
            foreach (int postId in _msgs)
            {
                p.WriteInt(postId);
                p.WriteInt(status);
            }
            return p;
        }
    }
}