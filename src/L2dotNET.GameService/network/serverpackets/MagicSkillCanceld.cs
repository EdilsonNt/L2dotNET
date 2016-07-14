namespace L2dotNET.GameService.Network.Serverpackets
{
    public class MagicSkillCanceld
    {
        private readonly int _id;

        public MagicSkillCanceld(int id)
        {
            _id = id;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x49);
            p.WriteInt(_id);
        }
    }
}