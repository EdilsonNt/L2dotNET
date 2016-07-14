using L2dotNET.GameService.Model.Communities;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeReceiveSubPledgeCreated
    {
        private readonly EClanSub _sub;

        public PledgeReceiveSubPledgeCreated(EClanSub sub)
        {
            _sub = sub;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x40);

            p.WriteInt(0x01);
            p.WriteInt((short)_sub.Type);
            p.WriteString(_sub.Name);
            p.WriteString(_sub.LeaderName);
        }
    }
}