using System.Collections.Generic;
using System.Linq;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.GameService.Tables;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class RecipeBookItemList
    {
        private readonly int _type;
        private readonly int _mp;
        private readonly List<L2Recipe> _book;

        public RecipeBookItemList(L2Player player, int type)
        {
            _type = type;
            _mp = (int)player.CharacterStat.GetStat(EffectType.BMaxMp);
            _book = new List<L2Recipe>();

            if (player.RecipeBook == null)
            {
                return;
            }

            foreach (L2Recipe rec in player.RecipeBook.Where(rec => rec.Iscommonrecipe == type))
            {
                _book.Add(rec);
            }
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xdc);
            p.WriteInt(_type);
            p.WriteInt(_mp);

            p.WriteInt(_book.Count);

            int x = 0;
            foreach (L2Recipe rec in _book)
            {
                p.WriteInt(rec.RecipeId);
                p.WriteInt(x);
                x++; //?
            }
        }
    }
}