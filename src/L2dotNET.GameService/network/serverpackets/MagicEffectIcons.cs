using System.Collections.Generic;

namespace L2dotNET.GameService.Network.Serverpackets
{
    public class MagicEffectIcons
    {
        private readonly List<int[]> _timers = new List<int[]>();

        public void AddIcon(int id, int lvl, int duration)
        {
            _timers.Add(new[] { id, lvl, duration });
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x85);
            p.WriteShort((short)_timers.Count);

            foreach (int[] f in _timers)
            {
                p.WriteInt(f[0]); //id
                p.WriteShort((short)f[1]); //lvl

                int duration = f[2];

                if (f[2] == -1)
                {
                    duration = -1;
                }

                if ((f[0] >= 5123) && (f[0] <= 5129))
                {
                    duration = -1;
                }

                p.WriteInt(duration);
            }
        }
    }
}