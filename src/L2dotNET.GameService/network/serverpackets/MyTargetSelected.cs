using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class MyTargetSelected
    {
        private const byte Opcode = 0xa6;

        internal static Packet ToPacket(int targetId, short color)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(targetId);
            p.WriteShort(color);
            return p;
        }
    }
}