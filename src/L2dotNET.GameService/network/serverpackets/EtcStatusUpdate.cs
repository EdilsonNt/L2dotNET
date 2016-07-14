using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class EtcStatusUpdate
    {
        private static int _force;
        private static int _weight;
        private static int _whisper;
        private static int _danger;
        private static int _grade;
        private static int _death;

        private const byte Opcode = 0xF3;
        internal static Packet ToPacket(L2Player player)
        {
            Packet p = new Packet(Opcode);
            _force = player.GetForceIncreased();
            _weight = player.PenaltyWeight;
            _whisper = player.WhisperBlock ? 1 : 0;
            _danger = player.IsInDanger ? 1 : 0;
            _grade = player.PenaltyGrade;
            _death = player.DeathPenaltyLevel;
            p.WriteInt(_force);
            p.WriteInt(_weight);
            p.WriteInt(_whisper);
            p.WriteInt(_danger); // 1 = danger area
            p.WriteInt(_grade);
            p.WriteInt(0); // 1 = charm of courage (no xp loss in siege..)
            p.WriteInt(_death);
            //p.WriteInt(_souls);
            return p;
        }
    }
}