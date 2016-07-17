using System;
using System.Collections.Generic;
using L2dotNET.GameService.Model.Inventory;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharacterSelectionInfo
    {
        private const byte Opcode = 0x13;

        internal static Packet ToPacket(string account, List<L2Player> players, int sessionId, int charId = -1)
        {
            Packet p = new Packet(Opcode);

            p.WriteInt(players.Count);

            foreach (L2Player player in players)
            {
                p.WriteString(player.Name);
                p.WriteInt(player.ObjId);
                p.WriteString(account);
                p.WriteInt(sessionId);
                p.WriteInt(player.ClanId);
                p.WriteInt(0x00); // ??

                p.WriteInt(player.Sex);
                p.WriteInt((int)player.BaseClass.ClassId.ClassRace);

                if (player.ActiveClass.ClassId.Id == player.BaseClass.ClassId.Id)
                {
                    p.WriteInt((int)player.ActiveClass.ClassId.Id);
                }
                else
                {
                    p.WriteInt((int)player.BaseClass.ClassId.Id);
                }

                p.WriteInt(0x01); // active ??
                p.WriteInt(player.X, player.Y, player.Z);
                p.WriteDouble(player.CurHp, player.CurMp);
                p.WriteInt(player.Sp);
                p.WriteLong(player.Exp);

                p.WriteInt(player.Level, player.Karma, player.PkKills, player.PvpKills);

                p.WriteInt(0, 0 , 0 , 0 , 0 , 0, 0);

                for (byte id = 0; id < Inventory.PaperdollTotalslots; id++)
                {
                    p.WriteInt(player.Inventory.Paperdoll?[id]?.Template?.ItemId ?? 0);

                }

                for (byte id = 0; id < Inventory.PaperdollTotalslots; id++)
                {
                     p.WriteInt(player.Inventory.Paperdoll?[id]?.Template?.ItemId ?? 0);
                }

                p.WriteInt(player.HairStyle, player.HairColor, player.Face);
                p.WriteDouble(player.MaxHp,player.MaxMp);
                p.WriteInt(0); // days left before TODO

                p.WriteInt((int)player.ActiveClass.ClassId.Id);

                int selection = 0;

                if (charId != -1)
                {
                    selection = charId == player.ObjId ? 1 : 0;
                }

                if ((charId == -1) && (player.LastAccountSelection == 1))
                {
                    selection = 1;
                }

                p.WriteInt(selection); // auto-select char
                p.WriteByte(player.GetEnchantValue());
                p.WriteInt(0x00); // augment
            }
            return p;
        }
    }
}