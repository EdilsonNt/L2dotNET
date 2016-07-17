using System.Collections.Generic;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExSendManorList
    {
        private const short Opcode = 0x1B;

        static readonly List<string> ManorsName = new List<string>
                                      {
                                          "gludio",
                                          "dion",
                                          "giran",
                                          "oren",
                                          "aden",
                                          "innadril",
                                          "goddard",
                                          "rune",
                                          "schuttgart"
                                      };
        internal static Packet ToPacket()
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(ManorsName.Count);

            int id = 1;
            foreach (string manor in ManorsName)
            {
                p.WriteInt(id);
                id++;
                p.WriteString(manor);
            }
            return p;
        }
    }
}