using System.Collections.Generic;
using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    public class MagicSkillLaunched
    {
        private const byte Opcode = 0x76;

        internal static Packet ToPacket(L2Character caster, List<int> targets, int id, int lvl)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(caster.ObjId);
            p.WriteInt(id);
            p.WriteInt(lvl);
            p.WriteInt(targets.Count);
            foreach (int tid in targets)
            {
                p.WriteInt(tid);
            }
            return p;
        }
    }
}