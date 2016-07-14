using System.Collections.Generic;
using System.Linq;
using L2dotNET.GameService.Model.Items;
using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SellList
    {
        private readonly List<L2Item> _sells = new List<L2Item>();
        private readonly int _adena;

        public SellList(L2Player player)
        {
            foreach (L2Item item in player.GetAllItems().Where(item => item.Template.Tradable && (item.AugmentationId <= 0) && (item.IsEquipped != 1)))
            {
                _sells.Add(item);
            }

            _adena = player.GetAdena();
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x10);
            p.WriteInt(_adena);
            p.WriteInt(0);
            p.WriteShort(_sells.Count);

            foreach (L2Item item in _sells)
            {
                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(item.Count);

                p.WriteShort(item.Template.Type2);
                p.WriteShort(item.Template.Type1);
                p.WriteInt(item.Template.BodyPart);

                p.WriteShort(item.Enchant);
                p.WriteShort(item.Template.Type2);
                p.WriteShort(0x00);
                p.WriteInt((int)(item.Template.ReferencePrice * 0.5));
            }
        }
    }
}