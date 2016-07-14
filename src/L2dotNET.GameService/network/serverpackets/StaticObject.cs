using L2dotNET.GameService.Model.Npcs.Decor;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class StaticObject
    {
        private readonly L2StaticObject _obj;

        public StaticObject(L2StaticObject obj)
        {
            _obj = obj;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x99);
            p.WriteInt(_obj.StaticId);
            p.WriteInt(_obj.ObjId);
        }
    }
}