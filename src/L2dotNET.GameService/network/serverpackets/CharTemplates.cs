using System.Collections.Generic;
using System.Linq;
using L2dotNET.GameService.Templates;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharTemplates
    {
        private readonly List<PcTemplate> _templates;

        public CharTemplates(List<PcTemplate> templates)
        {
            _templates = templates;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x17);
            p.WriteInt(_templates.Count);

            foreach (PcTemplate t in _templates.TakeWhile(t => t != null))
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
        }
    }
}