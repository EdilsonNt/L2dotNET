﻿using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestRecordInfo : PacketBase
    {
        public RequestRecordInfo(Packet packet, GameClient client)
        {
            _client = client;
        }

        public override void Read()
        {
            // nothing
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            player.SendPacket(new UserInfo(player));
            player.SendPacket(new ExBrExtraUserInfo(player.ObjId, player.AbnormalBitMaskEvent));

            foreach (L2Object obj in player.KnownObjects.Values)
            {
                player.OnAddObject(obj, null, "Player " + player.Name + " recording replay with your character.");
            }
        }
    }
}