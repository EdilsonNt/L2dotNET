namespace L2dotNET.GameService.Network.Serverpackets
{
    class LeaveWorld
    {
        protected internal override void Write()
        {
            WriteC(0x7e);
        }
    }
}