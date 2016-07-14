using System.Collections.Generic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Quests;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class QuestList
    {
        private readonly List<QuestInfo> _list;

        public QuestList(L2Player player)
        {
            _list = player.GetAllActiveQuests();
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x86);
            p.WriteShort((short)_list.Count);

            foreach (QuestInfo qi in _list)
            {
                p.WriteInt(qi.Id);
                p.WriteInt(qi.Stage);
            }

            WriteB(new byte[128]);
        }
    }
}