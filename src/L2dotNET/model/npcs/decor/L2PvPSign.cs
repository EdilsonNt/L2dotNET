﻿using L2dotNET.model.player;
using L2dotNET.Network.serverpackets;
using L2dotNET.tables;

namespace L2dotNET.model.npcs.decor
{
    public class L2PvPSign : L2StaticObject
    {
        public L2PvPSign()
        {
            ObjId = IdFactory.Instance.NextId();
        }

        public override void NotifyAction(L2Player player)
        {
            player.SendPacket(new NpcHtmlMessage(player, Htm, ObjId, 0));
        }

        public override string AsString()
        {
            return $"L2PvP Sign:{ObjId} {StaticId} {ClanID}";
        }
    }
}