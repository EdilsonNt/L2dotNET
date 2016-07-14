using System.Collections.Generic;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExSendManorList
    {
        private readonly List<string> _list;

        public ExSendManorList(List<string> list)
        {
            _list = list;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xFE);
            p.WriteShort(0x1B);
            p.WriteInt(_list.Count);

            int id = 1;
            foreach (string manor in _list)
            {
                p.WriteInt(id);
                id++;
                p.WriteString(manor);
            }
        }
    }
}