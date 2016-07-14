using System.Collections.Generic;
using System.Linq;
using L2dotNET.GameService.Templates;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharTemplates
    {
        private const byte Opcode = 0x17;

        internal static Packet ToPacket(List<PcTemplate> templates)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(templates.Count);

            foreach (PcTemplate t in templates.TakeWhile(t => t != null))
            {
                p.WriteInt((int)t.ClassId.ClassRace); //race id
                p.WriteInt((int)t.ClassId.Id);
                p.WriteInt(0x46);
                p.WriteInt(t.BaseStr);
                p.WriteInt(0x0a);
                p.WriteInt(0x46);
                p.WriteInt(t.BaseDex);
                p.WriteInt(0x0a);
                p.WriteInt(0x46);
                p.WriteInt(t.BaseCon);
                p.WriteInt(0x0a);
                p.WriteInt(0x46);
                p.WriteInt(t.BaseInt);
                p.WriteInt(0x0a);
                p.WriteInt(0x46);
                p.WriteInt(t.BaseWit);
                p.WriteInt(0x0a);
                p.WriteInt(0x46);
                p.WriteInt(t.BaseMen);
                p.WriteInt(0x0a);
            }
            return p;
        }
    }
}