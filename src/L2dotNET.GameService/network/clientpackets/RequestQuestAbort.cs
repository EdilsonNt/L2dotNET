﻿using System.Linq;
using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Quests;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestQuestAbort : PacketBase
    {
        public RequestQuestAbort(Packet packet, GameClient client)
        {
            _client = client;
        }

        private int _questId;

        public override void Read()
        {
            _questId = packet.ReadInt();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            foreach (QuestInfo qi in player.Quests.Where(qi => qi.Id == _questId))
            {
                if (qi.Completed)
                {
                    player.SendActionFailed();
                    return;
                }

                //foreach (int id in qi._template.actItems)
                //    player.Inventory.Dest(id, true, false);

                player.SendMessage("Quest " + qi.Template.QuestName + " aborted.");
                player.StopQuest(qi, true);
                return;
            }

            player.SendActionFailed();
        }
    }
}