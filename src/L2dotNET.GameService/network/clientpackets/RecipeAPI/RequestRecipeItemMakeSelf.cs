﻿using System;
using System.Linq;
using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.GameService.Tables;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets.RecipeAPI
{
    class RequestRecipeItemMakeSelf : PacketBase
    {
        private int _id;
        private readonly GameClient _client;

        public RequestRecipeItemMakeSelf(Packet packet, GameClient client)
        {
            _client = client;
            _id = packet.ReadInt();
        }

        public override void RunImpl()
        {
            L2Player player = _client.CurrentPlayer;

            if (player.RecipeBook == null)
            {
                player.SendSystemMessage(SystemMessage.SystemMessageId.RecipeIncorrect);
                player.SendActionFailed();
                return;
            }

            L2Recipe rec = player.RecipeBook.FirstOrDefault(r => r.RecipeId == _id);

            if (rec == null)
            {
                player.SendSystemMessage(SystemMessage.SystemMessageId.RecipeIncorrect);
                player.SendActionFailed();
                return;
            }

            if (player.CurMp < rec.MpConsume)
            {
                player.SendSystemMessage(SystemMessage.SystemMessageId.NotEnoughMp);
                player.SendActionFailed();
                return;
            }

            bool next;

            if (rec.Iscommonrecipe == 0)
            {
                next = player.PCreateItem >= rec.Level;
            }
            else
            {
                next = player.PCreateCommonItem >= rec.Level;
            }

            if (!next)
            {
                player.SendSystemMessage(SystemMessage.SystemMessageId.CreateLvlTooLowToRegister);
                player.SendActionFailed();
                return;
            }

            player.CurMp -= rec.MpConsume;
            StatusUpdate su = new StatusUpdate(player.ObjId);
            su.Add(StatusUpdate.CurMp, (int)player.CurMp);
            player.SendPacket(su);

            foreach (RecipeItemEntry material in rec.Materials)
            {
                player.DestroyItemById(material.Item.ItemId, material.Count);
            }

            if (rec.SuccessRate < 100)
            {
                if (new Random().Next(0, 100) > rec.SuccessRate)
                {
                    player.SendPacket(new RecipeItemMakeInfo(player, rec, 0));
                    player.SendActionFailed();
                    return;
                }
            }

            foreach (RecipeItemEntry prod in rec.Products)
            {
                player.AddItem(prod.Item.ItemId, prod.Count);
            }

            player.SendPacket(new RecipeItemMakeInfo(player, rec, 1));
        }
    }
}