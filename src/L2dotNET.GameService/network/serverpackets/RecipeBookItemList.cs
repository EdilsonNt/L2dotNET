using System.Collections.Generic;
using System.Linq;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.GameService.Tables;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class RecipeBookItemList
    {
        private const byte Opcode = 0xD6;

        internal static Packet ToPacket(L2Player player, int type)
        {
            List<L2Recipe> book = new List<L2Recipe>();
            Packet p = new Packet(Opcode);
            if (player.RecipeBook != null)
            {
                foreach (L2Recipe rec in player.RecipeBook.Where(rec => rec.Iscommonrecipe == type))
                {
                    book.Add(rec);
                }
                
                p.WriteInt(type);
                p.WriteInt((int) player.CharacterStat.GetStat(EffectType.BMaxMp));

                p.WriteInt(book.Count);

                int x = 0;
                foreach (L2Recipe rec in book)
                {
                    p.WriteInt(rec.RecipeId);
                    p.WriteInt(x);
                    x++; //?
                }
            }
            return p;
        }
    }
}