using System.Collections.Generic;
using System.Linq;
using L2dotNET.GameService.Model.Items;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExBuySellListSell
    {
        private static readonly List<L2Item> _sells = new List<L2Item>();
        private static readonly List<L2Item> _refund;
        private const short Opcode = 0xB7;

        internal static Packet ToPacket(L2Player player)
        {
            foreach (L2Item item in player.GetAllItems().Where(item => !item.NotForTrade()))
            {
                _sells.Add(item);
            }
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(1);
            p.WriteShort((short)_sells.Count);

            foreach (L2Item item in _sells)
            {
                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(0);
                p.WriteInt(item.Count);
                p.WriteShort((short)item.Template.Type2);
                p.WriteShort((short)item.CustomType1);
                p.WriteShort(0);
                p.WriteInt(item.Template.BodyPart);
                p.WriteShort((short)item.Enchant);
                p.WriteShort((short)item.CustomType2);
                p.WriteInt(item.AugmentationId);
                p.WriteInt(item.Durability);
                p.WriteInt(item.LifeTimeEnd());

                p.WriteShort(item.AttrAttackType);
                p.WriteShort(item.AttrAttackValue);
                p.WriteShort(item.AttrDefenseValueFire);
                p.WriteShort(item.AttrDefenseValueWater);
                p.WriteShort(item.AttrDefenseValueWind);
                p.WriteShort(item.AttrDefenseValueEarth);
                p.WriteShort(item.AttrDefenseValueHoly);
                p.WriteShort(item.AttrDefenseValueUnholy);

                p.WriteShort(item.Enchant1);
                p.WriteShort(item.Enchant2);
                p.WriteShort(item.Enchant3);

                p.WriteInt(item.Template.ReferencePrice / 2);
            }

            p.WriteShort((short)_refund.Count);

            int idx = 0;
            foreach (L2Item item in _refund)
            {
                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(0);
                p.WriteInt(item.Count);
                p.WriteShort((short)item.Template.Type2);
                p.WriteShort((short)item.CustomType1);
                p.WriteShort(0);
                p.WriteInt(item.Template.BodyPart);
                p.WriteShort((short)item.Enchant);
                p.WriteShort((short)item.CustomType2);
                p.WriteInt(item.AugmentationId);
                p.WriteInt(item.Durability);
                p.WriteInt(item.LifeTimeEnd());

                p.WriteShort(item.AttrAttackType);
                p.WriteShort(item.AttrAttackValue);
                p.WriteShort(item.AttrDefenseValueFire);
                p.WriteShort(item.AttrDefenseValueWater);
                p.WriteShort(item.AttrDefenseValueWind);
                p.WriteShort(item.AttrDefenseValueEarth);
                p.WriteShort(item.AttrDefenseValueHoly);
                p.WriteShort(item.AttrDefenseValueUnholy);

                p.WriteShort(item.Enchant1);
                p.WriteShort(item.Enchant2);
                p.WriteShort(item.Enchant3);

                p.WriteInt(idx++);
                p.WriteInt((item.Template.ReferencePrice / 2) * item.Count);
            }

            p.WriteInt(0);
            return p;
        }
        
    }
}