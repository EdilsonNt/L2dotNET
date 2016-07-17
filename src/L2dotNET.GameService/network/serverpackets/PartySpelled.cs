using System.Collections.Generic;
using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PartySpelled
    {
        private const byte Opcode = 0xee;
        private static readonly List<int[]> _timers = new List<int[]>();

        public void AddIcon(int iconId, int lvl, int duration)
        {
            _timers.Add(new[] { iconId, lvl, duration });
        }

        internal static Packet ToPacket(L2Character character)
        {
            Packet p = new Packet(Opcode);
            if (character != null)
            {
                
                p.WriteInt(character.ObjectSummonType);
                p.WriteInt(character.ObjId);
                p.WriteInt(_timers.Count);

                foreach (int[] f in _timers)
                {
                    p.WriteInt(f[0]); //id
                    p.WriteShort((short) f[1]); //lvl

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
            return p;
        }
    }
}