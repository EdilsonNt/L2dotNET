using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PetDelete
    {
        private const byte Opcode = 0xb6;

        internal static Packet ToPacket(byte objectSummonType, int objId)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(objectSummonType);
            p.WriteInt(objId);
            return p;
        }
    }
}