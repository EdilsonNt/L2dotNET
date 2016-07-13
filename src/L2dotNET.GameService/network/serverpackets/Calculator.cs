namespace L2dotNET.GameService.Network.Serverpackets
{
    class Calculator
    {
        protected internal override void Write()
        {
            WriteC(0xe2);
            WriteD(4393);
        }
    }
}