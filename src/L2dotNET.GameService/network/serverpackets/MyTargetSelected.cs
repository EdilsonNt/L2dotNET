namespace L2dotNET.GameService.Network.Serverpackets
{
    class MyTargetSelected
    {
        private readonly int _targetId;
        private readonly short _color;

        public MyTargetSelected(int target, int color)
        {
            _targetId = target;
            _color = (short)color;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xa6);
            p.WriteInt(_targetId);
            p.WriteShort(_color);
        }
    }
}