using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class EtcStatusUpdate
    {
        private readonly int _force;
        private readonly int _weight;
        private readonly int _whisper;
        private readonly int _danger;
        private readonly int _grade;
        private int _death;
        private int _souls;

        public EtcStatusUpdate(L2Player player)
        {
            _force = player.GetForceIncreased();
            _weight = player.PenaltyWeight;
            _whisper = player.WhisperBlock ? 1 : 0;
            _danger = player.IsInDanger ? 1 : 0;
            _grade = player.PenaltyGrade;
            _death = player.DeathPenaltyLevel;
            _souls = player.Souls;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xF3);
            p.WriteInt(_force);
            p.WriteInt(_weight);
            p.WriteInt(_whisper);
            p.WriteInt(_danger); // 1 = danger area
            p.WriteInt(_grade);
            p.WriteInt(0); // 1 = charm of courage (no xp loss in siege..)
            //p.WriteInt(_death);
            //p.WriteInt(_souls);
        }
    }
}