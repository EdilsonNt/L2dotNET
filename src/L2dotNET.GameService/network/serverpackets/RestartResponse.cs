namespace L2dotNET.GameService.Network.Serverpackets
{
    class RestartResponse
    {
        protected internal override void Write()
        {
            WriteC(0x5f);
            WriteD(0x01);
        }
    }
}