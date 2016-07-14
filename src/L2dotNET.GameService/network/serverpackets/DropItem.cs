using L2dotNET.GameService.Model.Items;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class DropItem
    { 
        private const byte Opcode = 0x0c;

        internal static Packet ToPacket(L2Item item)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(item.Dropper);
            p.WriteInt(item.ObjId);
            p.WriteInt(item.Template.ItemId);
            p.WriteInt(item.X, item.Y, item.Z);
            p.WriteInt(item.Template.Stackable ? 1 : 0);
            p.WriteInt(item.Count);
            p.WriteInt(1); // ?
            return p;
        }
    }
}