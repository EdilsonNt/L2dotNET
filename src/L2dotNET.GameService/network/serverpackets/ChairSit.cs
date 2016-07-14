using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    internal class ChairSit
    {
        private const byte Opcode = 0xe1;

        internal static Packet ToPacket(int sId, int staticId)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(sId);
            p.WriteInt(staticId);
            return p;
        }
    }
}