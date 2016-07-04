﻿using L2dotNET.GameService.Managers;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestTradeDone : GameServerNetworkRequest
    {
        private bool bDone;

        public RequestTradeDone(GameClient client, byte[] data)
        {
            makeme(client, data);
        }

        public override void read()
        {
            bDone = readD() == 1;
        }

        public override void run()
        {
            L2Player player = Client.CurrentPlayer;

            if (player.TradeState < 3) // умник
            {
                player.SendActionFailed();
                return;
            }

            if (player.requester == null)
            {
                player.SendMessage("Your trade requestor has logged off.");
                player.SendActionFailed();
                player.TradeState = 0;

                if (player.currentTrade != null)
                    player.currentTrade.Clear();

                return;
            }

            if (bDone)
            {
                player.TradeState = 4;
                player.requester.SendPacket(new SystemMessage(SystemMessage.SystemMessageId.S1_CONFIRMED_TRADE).AddPlayerName(player.Name));

                if (player.requester.TradeState == 4)
                    TradeManager.getInstance().PersonalTrade(player, player.requester);
            }
            else
            {
                TradeDone end = new TradeDone(false);
                player.TradeState = 0;
                player.currentTrade.Clear();
                player.SendPacket(end);
                player.requester.SendPacket(new SystemMessage(SystemMessage.SystemMessageId.S1_CANCELED_TRADE).AddPlayerName(player.Name));

                player.requester.TradeState = 0;
                player.requester.currentTrade.Clear();
                player.requester.SendPacket(end);
                player.requester = null;
            }
        }
    }
}