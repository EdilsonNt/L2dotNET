using System;
using System.Collections.Generic;
using L2dotNET.GameService.Model.Inventory;
using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharacterSelectionInfo
    {
        private readonly List<L2Player> _players;
        public int CharId = -1;
        private readonly string _account;
        private readonly int _sessionId;

        public CharacterSelectionInfo(string account, List<L2Player> players, int sessionId)
        {
            _players = players;
            _account = account;
            _sessionId = sessionId;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x13);
            p.WriteInt(_players.Count);

            foreach (L2Player player in _players)
            {
                p.WriteString(player.Name);
                p.WriteInt(player.ObjId);
                p.WriteString(_account);
                p.WriteInt(_sessionId);
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

                p.WriteInt(player.X);
                p.WriteInt(player.Y);
                p.WriteInt(player.Z);

                p.WriteDouble(player.CurHp);
                p.WriteDouble(player.CurMp);

                p.WriteInt(player.Sp);
                p.WriteInt(player.Exp);

                p.WriteInt(player.Level);
                p.WriteInt(player.Karma);
                p.WriteInt(player.PkKills);
                p.WriteInt(player.PvpKills);

                p.WriteInt(0);
                p.WriteInt(0);
                p.WriteInt(0);
                p.WriteInt(0);
                p.WriteInt(0);
                p.WriteInt(0);
                p.WriteInt(0);

                for (byte id = 0; id < Inventory.PaperdollTotalslots; id++)
                {
                    try
                    {
                        p.WriteInt(player.Inventory.Paperdoll[id].Template.ItemId);
                    }
                    catch (Exception e)
                    {
                        p.WriteInt(0);
                    }
                    
                }

                for (byte id = 0; id < Inventory.PaperdollTotalslots; id++)
                {
                    try
                    {
                        p.WriteInt(player.Inventory.Paperdoll[id].Template.ItemId);
                    }
                    catch (Exception e)
                    {
                        p.WriteInt(0);
                    }

                }

                p.WriteInt(player.HairStyle);
                p.WriteInt(player.HairColor);

                p.WriteInt(player.Face);
                p.WriteDouble(player.CurHp); // hp max TODO
                p.WriteDouble(player.CurMp); // mp max TODO
                p.WriteInt(0); // days left before TODO

                p.WriteInt((int)player.ActiveClass.ClassId.Id);

                int selection = 0;

                if (CharId != -1)
                {
                    selection = CharId == player.ObjId ? 1 : 0;
                }

                if ((CharId == -1) && (player.LastAccountSelection == 1))
                {
                    selection = 1;
                }

                p.WriteInt(selection); // auto-select char
                p.WriteInt(player.GetEnchantValue());
                p.WriteInt(0x00); // augment
            }
        }
    }
}