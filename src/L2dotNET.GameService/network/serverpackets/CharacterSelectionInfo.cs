﻿using System.Collections.Generic;
using L2dotNET.GameService.Model.Inventory;
using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharacterSelectionInfo : GameServerNetworkPacket
    {
        private readonly List<L2Player> players;
        public int charId = -1;
        private readonly string account;
        private readonly int sessionId;

        public CharacterSelectionInfo(string account, List<L2Player> players, int sessionId)
        {
            this.players = players;
            this.account = account;
            this.sessionId = sessionId;
        }

        protected internal override void write()
        {
            writeC(0x13);
            writeD(players.Count);

            foreach (L2Player player in players)
            {
                writeS(player.Name);
                writeD(player.ObjId);
                writeS(account);
                writeD(sessionId);
                writeD(player.ClanId);
                writeD(0x00); // ??

                writeD(player.Sex);
                writeD((int)player.BaseClass.ClassId.ClassRace);

                if (player.ActiveClass.ClassId.Id == player.BaseClass.ClassId.Id)
                    writeD((int)player.ActiveClass.ClassId.Id);
                else
                    writeD((int)player.BaseClass.ClassId.Id);

                writeD(0x01); // active ??

                writeD(player.X);
                writeD(player.Y);
                writeD(player.Z);

                writeF(player.CurHp);
                writeF(player.CurMp);

                writeD(player.SP);
                writeQ(player.Exp);

                writeD(player.Level);
                writeD(player.Karma);
                writeD(player.PkKills);
                writeD(player.PvpKills);

                writeD(0);
                writeD(0);
                writeD(0);
                writeD(0);
                writeD(0);
                writeD(0);
                writeD(0);

                for (byte id = 0; id < Inventory.PaperdollTotalslots; id++)
                    writeD(player.Inventory.Paperdoll[id].Template.ItemID);

                for (byte id = 0; id < Inventory.PaperdollTotalslots; id++)
                    writeD(player.Inventory.Paperdoll[id].Template.ItemID);

                writeD(player.HairStyle);
                writeD(player.HairColor);

                writeD(player.Face);
                writeF(player.CurHp); // hp max TODO
                writeF(player.CurMp); // mp max TODO
                writeD(0); // days left before TODO

                writeD((int)player.ActiveClass.ClassId.Id);

                int selection = 0;

                if (charId != -1)
                    selection = charId == player.ObjId ? 1 : 0;

                if ((charId == -1) && (player.LastAccountSelection == 1))
                    selection = 1;

                writeD(selection); // auto-select char
                writeC(player.GetEnchantValue());
                writeD(0x00); // augment
            }
        }
    }
}