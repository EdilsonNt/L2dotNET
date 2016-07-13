namespace L2dotNET.GameService.Network.Serverpackets
{
    class ActionFailed
    {
        protected internal override void Write()
        {
            WriteC(0x25);
        }
    }
}