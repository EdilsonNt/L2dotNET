using L2dotNET.GameService.Model.Items;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class DropItem
    {
        private readonly int _id;
        private readonly L2Item _item;

        public DropItem(L2Item item)
        {
            _item = item;
            _id = item.Dropper;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x0c);
            p.WriteInt(_id);
            p.WriteInt(_item.ObjId);
            p.WriteInt(_item.Template.ItemId);
            p.WriteInt(_item.X);
            p.WriteInt(_item.Y);
            p.WriteInt(_item.Z);
            p.WriteInt(_item.Template.Stackable ? 1 : 0);
            p.WriteInt(_item.Count);
            p.WriteInt(1); // ?
        }
    }
}