namespace L2dotNET.GameService.Network.Serverpackets
{
    class DeleteObject
    {
        private readonly int _id;

        public DeleteObject(int id)
        {
            _id = id;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x12);
            p.WriteInt(_id);
            p.WriteInt(0);
        }
    }
}