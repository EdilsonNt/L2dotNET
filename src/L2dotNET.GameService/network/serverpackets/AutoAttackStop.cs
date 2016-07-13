namespace L2dotNET.GameService.Network.Serverpackets
{
    class AutoAttackStop
    {
        private readonly int _sId;

        public AutoAttackStop(int sId)
        {
            _sId = sId;
        }

        protected internal override void Write()
        {
            WriteC(0x2c);
            WriteD(_sId);
        }
    }
}