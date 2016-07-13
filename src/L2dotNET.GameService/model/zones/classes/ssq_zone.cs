﻿using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.GameService.Tables;
using L2dotNET.GameService.World;

namespace L2dotNET.GameService.Model.Zones.Classes
{
    class ssq_zone : L2Zone
    {
        public ssq_zone()
        {
            ZoneId = IdFactory.Instance.NextId();
            Enabled = true;
        }

        public override void OnEnter(L2Object obj)
        {
            if (!Enabled)
            {
                return;
            }

            base.OnEnter(obj);

            obj.OnEnterZone(this);

            if (!(obj is L2Player))
            {
                return;
            }

            L2Player p = (L2Player)obj;
            p.SendSystemMessage((SystemMessage.SystemMessageId)Template.EnteringMessageNo);
        }

        public override void OnExit(L2Object obj, bool cls)
        {
            if (!Enabled)
            {
                return;
            }

            base.OnExit(obj, cls);

            obj.OnExitZone(this, cls);

            if (!(obj is L2Player))
            {
                return;
            }

            L2Player p = (L2Player)obj;
            p.SendSystemMessage((SystemMessage.SystemMessageId)Template.LeavingMessageNo);
        }
    }
}