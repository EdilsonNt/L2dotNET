using System.Collections.Generic;
using L2dotNET.GameService.Model.Items;
using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class WareHouseWithdrawalList
    {
        public static short WhPrivate = 1;
        public static short WhClan = 2;
        public static short WhCastle = 3;
        public static short WhFreight = 4;
        private readonly List<L2Item> _items;
        private readonly short _type;
        private readonly long _adena;

        public WareHouseWithdrawalList(L2Player player, List<L2Item> items, short type)
        {
            _type = type;
            _adena = player.GetAdena();
            _items = items;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x42);
            p.WriteShort(_type);
            p.WriteInt(_adena);
            p.WriteShort(_items.Count);

            foreach (L2Item item in _items)
            {
                p.WriteShort(item.Template.Type1);
                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(item.Count);
                p.WriteShort(item.Template.Type2);
                p.WriteShort(0); //custom type 1
                p.WriteInt(item.Template.BodyPart);
                p.WriteShort(item.Enchant);
                p.WriteShort(0); //custom type 2
                p.WriteShort(0);
                //p.WriteInt(item.AugmentationID);
                p.WriteInt(item.ObjId);
                p.WriteInt(0x00);
            }
        }
    }
}