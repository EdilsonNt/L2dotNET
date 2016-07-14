using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ActionFailed
    {
        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0x25);
        }
    }
}