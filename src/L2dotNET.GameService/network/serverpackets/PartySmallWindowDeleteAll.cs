namespace L2dotNET.GameService.Network.Serverpackets
{
    class PartySmallWindowDeleteAll
    {
        protected internal override void Write()
        {
            WriteC(0x50);
        }
    }
}