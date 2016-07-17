using L2dotNET.GameService.Model.Communities;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeReceiveSubPledgeCreated
    {
        private const byte Opcode = 0x3f;

        internal static Packet ToPacket(EClanSub sub)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);

            p.WriteInt(0x01);
            p.WriteInt((short)sub.Type);
            p.WriteString(sub.Name);
            p.WriteString(sub.LeaderName);
            return p;
        }
    }
}