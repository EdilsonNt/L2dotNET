using L2dotNET.GameService.Enums;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class EnchantResult
    {
        private const byte Opcode = 0x81;

        internal static Packet ToPacket(EnchantResultVal result, int crystal = 0, int count = 0)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt((int)result);
            p.WriteInt(crystal);
            p.WriteInt(count);
            return p;
        }
    }
}