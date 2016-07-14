using System.Collections.Generic;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExSendManorList
    {
        private const short Opcode = 0x1B;

        internal static Packet ToPacket(List<string> list)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(list.Count);

            int id = 1;
            foreach (string manor in list)
            {
                p.WriteInt(id);
                id++;
                p.WriteString(manor);
            }
            return p;
        }
    }
}