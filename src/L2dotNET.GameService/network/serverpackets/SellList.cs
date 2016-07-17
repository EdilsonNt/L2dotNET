using System.Collections.Generic;
using System.Linq;
using L2dotNET.GameService.Model.Items;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SellList
    {
        private const byte Opcode = 0x10;
        private static readonly List<L2Item> Sells = new List<L2Item>();

        internal static Packet ToPacket(L2Player player)
        {
            foreach (L2Item item in player.GetAllItems().Where(item => item.Template.Tradable && (item.AugmentationId <= 0) && (item.IsEquipped != 1)))
            {
                Sells.Add(item);
            }
            Packet p = new Packet(Opcode);
            p.WriteInt(player.GetAdena());
            p.WriteInt(0);
            p.WriteShort((short)Sells.Count);

            foreach (L2Item item in Sells)
            {
                p.WriteInt(item.ObjId);
                p.WriteInt(item.Template.ItemId);
                p.WriteInt(item.Count);

                p.WriteShort((short)item.Template.Type2);
                p.WriteShort((short)item.Template.Type1);
                p.WriteInt(item.Template.BodyPart);

                p.WriteShort(item.Enchant);
                p.WriteShort((short)item.Template.Type2);
                p.WriteShort(0x00);
                p.WriteInt((int)(item.Template.ReferencePrice * 0.5));
            }
            return p;
        }
    }
}