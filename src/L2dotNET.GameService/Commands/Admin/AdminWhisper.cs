﻿using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;

namespace L2dotNET.GameService.Commands.Admin
{
    class AdminWhisper : AAdminCommand
    {
        public AdminWhisper()
        {
            Cmd = "whisper";
        }

        protected internal override void Use(L2Player admin, string alias)
        {
            //whisper [on|off] -- so when whisper is off means no one can message you when whispers on they can message you.
            bool changed;
            switch (alias.Split(' ')[1])
            {
                case "on":
                    changed = admin.WhisperBlock = false;
                    admin.WhisperBlock = true;
                    admin.SendMessage("Whisper blocking enabled.");
                    break;
                case "off":
                    changed = admin.WhisperBlock = true;
                    admin.WhisperBlock = false;
                    admin.SendMessage("Whisper blocking disabled.");
                    break;
                default:
                    changed = admin.WhisperBlock = true;
                    admin.WhisperBlock = false;
                    admin.SendMessage("Whisper blocking disabled.");
                    break;
            }

            if (changed)
            {
                admin.SendPacket(EtcStatusUpdate.ToPacket(admin));
            }
        }
    }
}