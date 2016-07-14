using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharMoveToLocationMonrace
    {
        //private MonsterRunner runner;
        //public CharMoveToLocationMonrace(MonsterRunner runner)
        //{
        //    this.runner = runner;
        //}
        private const byte Opcode = 0x2f;
        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            return p;

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