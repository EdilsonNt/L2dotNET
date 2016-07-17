using System.Collections.Generic;
using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PartySpelled
    {
        private const byte Opcode = 0xee;

        public PartySpelled(L2Character character)
        {
            _id = character.ObjId;
            _summonType = character.ObjectSummonType;
            _character = character;
        }

        private static readonly List<int[]> _timers = new List<int[]>();
        private readonly int _id;
        private static L2Character _character;
        private readonly int _summonType;

        public void AddIcon(int iconId, int lvl, int duration)
        {
            _timers.Add(new[] { iconId, lvl, duration });
        }

        internal Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            if (_character != null)
            {
                
                p.WriteInt(_character.ObjectSummonType);
                p.WriteInt(_character.ObjId);
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