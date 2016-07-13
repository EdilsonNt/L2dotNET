namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharDeleteOk
    {
        protected internal override void Write()
        {
            WriteC(0x23);
        }
    }
}