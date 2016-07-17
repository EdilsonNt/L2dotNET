using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PetStatusShow
    {
        private const byte Opcode = 0xb1;

        internal static Packet ToPacket(byte objectSummonType)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(objectSummonType);
            return p;
        }
    }
}