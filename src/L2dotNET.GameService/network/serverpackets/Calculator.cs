using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class Calculator
    {
        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0xe2);
            p.WriteInt(4393);
        }
    }
}