using L2dotNET.GameService.Model.Items;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class SpawnItem
    {
        private readonly L2Item _item;

        public SpawnItem(L2Item item)
        {
            _item = item;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x0b);
            p.WriteInt(_item.ObjId);
            p.WriteInt(_item.Template.ItemId);
            p.WriteInt(_item.X);
            p.WriteInt(_item.Y);
            p.WriteInt(_item.Z);
            p.WriteInt(_item.Template.Stackable ? 1 : 0);
            p.WriteInt(_item.Count);
            p.WriteInt(0); // ?
        }
    }
}