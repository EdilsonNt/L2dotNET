using System.Collections.Generic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SkillCoolTime
    {
        private const byte Opcode = 0xc1;

        internal static Packet ToPacket(L2Player player)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(player.Reuse.Values.Count);

            foreach (L2SkillCoolTime ct in player.Reuse.Values)
            {
                p.WriteInt(ct.Id);
                p.WriteInt(ct.Lvl);
                p.WriteInt(ct.Total);
                p.WriteInt(ct.GetDelay());
            }
            return p;
        }
    }
}