namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharMoveToLocationMonrace
    {
        //private MonsterRunner runner;
        //public CharMoveToLocationMonrace(MonsterRunner runner)
        //{
        //    this.runner = runner;
        //}

        internal static Packet ToPacket()
        {
            p.WriteInt(0x2f);

            //p.WriteInt(runner.id);

            //p.WriteInt(runner.dx);
            //p.WriteInt(runner.dy);
            //p.WriteInt(runner.dz);

            //p.WriteInt(runner.x);
            //p.WriteInt(runner.y);
            //p.WriteInt(runner.z);
        }
    }
}