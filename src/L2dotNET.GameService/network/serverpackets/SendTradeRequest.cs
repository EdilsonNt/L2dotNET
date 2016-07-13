namespace L2dotNET.GameService.Network.Serverpackets
{
    class SendTradeRequest
    {
        private readonly int _sId;

        public SendTradeRequest(int sId)
        {
            _sId = sId;
        }

        protected internal override void Write()
        {
            WriteC(0x5e);
            WriteD(_sId);
        }
    }
}