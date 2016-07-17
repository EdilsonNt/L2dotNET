using System.Collections.Generic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Quests;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class QuestList
    {
        private const byte Opcode = 0x80;
        private static List<QuestInfo> _list;

        internal static Packet ToPacket(L2Player player)
        {
            _list = player.GetAllActiveQuests();
            Packet p = new Packet(Opcode);
            p.WriteShort((short)_list.Count);

            foreach (QuestInfo qi in _list)
            {
                p.WriteInt(qi.Id);
                p.WriteInt(qi.Stage);
            }

            p.WriteBytesArray(new byte[128]);
            return p;
        }
    }
}