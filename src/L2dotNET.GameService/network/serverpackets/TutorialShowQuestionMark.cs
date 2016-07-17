using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TutorialShowQuestionMark
    {
        private const byte Opcode = 0xa1;

        internal static Packet ToPacket(int id)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(id);
            return p;
        }
    }
}