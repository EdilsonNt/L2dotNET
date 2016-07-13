namespace L2dotNET.GameService.Network.Serverpackets
{
    class SunRise
    {
        protected internal override void Write()
        {
            WriteC(0x1c);
        }
    }
}