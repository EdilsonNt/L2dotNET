using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ShowMiniMap
    {
        private const byte Opcode = 0x9d;

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(1665);
            p.WriteInt(0); //SevenSigns.getInstance().getCurrentPeriod());
            return p;
        }
    }
}