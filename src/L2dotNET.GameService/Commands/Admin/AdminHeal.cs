﻿using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.GameService.Network.Serverpackets;

namespace L2dotNET.GameService.Commands.Admin
{
    class AdminHeal : AAdminCommand
    {
        public AdminHeal()
        {
            Cmd = "heal";
        }

        protected internal override void Use(L2Player admin, string alias)
        {
            //healthy -- восстанавливает выбранному чару хп\мп

            L2Player target;
            if (admin.CurrentTarget is L2Player)
            {
                target = (L2Player)admin.CurrentTarget;
            }
            else
            {
                target = admin;
            }

            double hpval = target.CharacterStat.GetStat(EffectType.BMaxHp) - target.CurHp;
            double mpval = target.CharacterStat.GetStat(EffectType.BMaxMp) - target.CurMp;
            target.CurHp += hpval;
            target.CurMp += mpval;

            StatusUpdate su = new StatusUpdate(target.ObjId);
            su.Add(StatusUpdate.CurHp, (int)target.CurHp);
            su.Add(StatusUpdate.CurMp, (int)target.CurMp);
            target.SendPacket(su);

            SystemMessage sm = new SystemMessage(SystemMessage.SystemMessageId.S2HpRestoredByS1);
            sm.AddPlayerName(admin.Name);
            sm.AddNumber((int)hpval);
            target.SendPacket(sm);

            sm = new SystemMessage(SystemMessage.SystemMessageId.S2MpRestoredByS1);
            sm.AddPlayerName(admin.Name);
            sm.AddNumber((int)mpval);
            target.SendPacket(sm);
        }
    }
}