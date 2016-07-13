namespace L2dotNET.GameService.Network.Serverpackets
{
    class SunSet
    {
        protected internal override void Write()
        {
            WriteC(0x1d);
        }
    }
}