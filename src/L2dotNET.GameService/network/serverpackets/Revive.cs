namespace L2dotNET.GameService.Network.Serverpackets
{
    class Revive
    {
        private readonly int _objId;

        public Revive(int objId)
        {
            _objId = objId;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x07);
            p.WriteInt(_objId);
        }
    }
}