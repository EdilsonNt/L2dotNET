using System.Collections.Generic;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    public class MagicEffectIcons
    {
        private static readonly List<int[]> _timers = new List<int[]>();
        private const byte Opcode = 0x85;

        public void AddIcon(int id, int lvl, int duration)
        {
            _timers.Add(new[] { id, lvl, duration });
        }

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
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
            return p;
        }
    }
}