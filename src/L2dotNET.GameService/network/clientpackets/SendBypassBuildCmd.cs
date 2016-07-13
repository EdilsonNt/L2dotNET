﻿using L2dotNET.GameService.Handlers;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class SendBypassBuildCmd : PacketBase
    {
        private string _alias;
        private readonly GameClient _client;

        public SendBypassBuildCmd(Packet packet, GameClient client)
        {
            _client = client;
            _alias = packet.ReadString().Trim();
        }

        public override void RunImpl()
        {
            L2Player player = _client.CurrentPlayer;

            AdminCommandHandler.Instance.Request(player, _alias);
        }
    }
}