using L2dotNET.GameService.Model.Items;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SpawnItem
    {
        private const byte Opcode = 0x0b;

        internal static Packet ToPacket(L2Item item)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(item.ObjId);
            p.WriteInt(item.Template.ItemId);
            p.WriteInt(item.X);
            p.WriteInt(item.Y);
            p.WriteInt(item.Z);
            p.WriteInt(item.Template.Stackable ? 1 : 0);
            p.WriteInt(item.Count);
            p.WriteInt(0); // ?
            return p;
        }
    }
}