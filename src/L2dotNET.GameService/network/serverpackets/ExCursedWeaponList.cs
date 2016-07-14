using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExCursedWeaponList
    {
        private const short Opcode = 0x46;

        internal static Packet ToPacket(int[] ids)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(ids.Length);

            foreach (int id in ids)
            {
                p.WriteInt(id);
            }
            return p;
        }
    }
}