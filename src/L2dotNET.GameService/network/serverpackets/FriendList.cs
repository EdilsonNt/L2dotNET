namespace L2dotNET.GameService.Network.Serverpackets
{
    class FriendList
    {
        protected internal override void Write()
        {
            WriteC(0xfa);
            WriteH(0x00);
            WriteH(0x00);
        }
    }
}