namespace L2dotNET.GameService.Network.Serverpackets
{
    class JoinParty
    {
        private readonly int _response;

        public JoinParty(int response)
        {
            _response = response;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x3a);
            p.WriteInt(_response);
        }
    }
}