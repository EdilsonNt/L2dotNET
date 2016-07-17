using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SendTradeRequest
    {
        private const byte Opcode = 0x5e;

        internal static Packet ToPacket(int senderId)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(senderId);
            return p;
        }
    }
}