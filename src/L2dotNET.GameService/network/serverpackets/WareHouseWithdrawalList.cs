using System.Collections.Generic;
using L2dotNET.GameService.Model.Items;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class WareHouseWithdrawalList
    {
        private const byte Opcode = 0x42;
        public static short WhPrivate = 1;
        public static short WhClan = 2;
        public static short WhCastle = 3;
        public static short WhFreight = 4;

        internal static Packet ToPacket(L2Player player, List<L2Item> items, short type)
        {
            Packet p = new Packet(Opcode);
            p.WriteShort(type);
            p.WriteInt(player.GetAdena());
            p.WriteShort((short)items.Count);

            foreach (L2Item item in items)
            {
                p.WriteShort((short)item.Template.Type1);
                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(item.Count);
                p.WriteShort((short)item.Template.Type2);
                p.WriteShort(0); //custom type 1
                p.WriteInt(item.Template.BodyPart);
                p.WriteShort(item.Enchant);
                p.WriteShort(0); //custom type 2
                p.WriteShort(0);
                //p.WriteInt(item.AugmentationID);
                p.WriteInt(item.ObjId);
                p.WriteInt(0x00);
            }
            return p;
        }
    }
}