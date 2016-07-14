namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExCursedWeaponList
    {
        private readonly int[] _ids;

        public ExCursedWeaponList(int[] ids)
        {
            _ids = ids;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x46);
            p.WriteInt(_ids.Length);

            foreach (int id in _ids)
            {
                p.WriteInt(id);
            }
        }
    }
}