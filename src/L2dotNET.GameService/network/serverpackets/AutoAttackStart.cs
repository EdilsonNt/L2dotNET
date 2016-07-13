namespace L2dotNET.GameService.Network.Serverpackets
{
    class AutoAttackStart
    {
        private readonly int _sId;

        public AutoAttackStart(int sId)
        {
            _sId = sId;
        }

        protected internal override void Write()
        {
            WriteC(0x2b);
            WriteD(_sId);
        }
    }
}