using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PledgeCrest
    {
        private const byte Opcode = 0x6a;

        internal static Packet ToPacket(int id, byte[] picture)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(id);
            if (picture != null)
            {
                p.WriteInt(picture.Length);
                p.WriteBytesArray(picture);
            }
            else
            {
                p.WriteInt(0);
            }
            return p;
        }
    }
}