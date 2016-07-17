using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    public class MagicSkillCanceld
    {
        private const byte Opcode = 0x49;

        internal static Packet ToPacket(int id)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(id);
            return p;
        }
    }
}