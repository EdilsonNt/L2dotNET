using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExPledgeCrestLarge
    {
        private const short Opcode = 0x1b;

        internal static Packet ToPacket(int id, byte[] picture)
        {
            if (picture == null)
            {
                picture = new byte[0];
            }

            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);

            p.WriteInt(0x00); //???
            p.WriteInt(id);
            p.WriteInt(picture.Length);
            p.WriteBytesArray(picture);
            return p;
        }
    }
}