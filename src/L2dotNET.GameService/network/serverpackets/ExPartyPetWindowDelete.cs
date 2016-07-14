using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExPartyPetWindowDelete
    {
        private const short Opcode = 0x6a;

        internal static Packet ToPacket(int petId, int playerId, string petName)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(petId);
            p.WriteInt(playerId);
            p.WriteString(petName);
            return p;
        }
    }
}