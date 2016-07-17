using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SocialAction
    {
        private const byte Opcode = 0x2d;

        internal static Packet ToPacket(int id, int social)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(id);
            p.WriteInt(social);
            return p;
        }
    }
}