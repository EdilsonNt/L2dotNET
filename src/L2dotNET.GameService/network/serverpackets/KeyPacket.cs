using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class KeyPacket
    {
        private const byte Opcode = 0x00;

        internal static Packet ToPacket(GameClient client, byte n)
        {
            Packet p = new Packet(Opcode);
            p.WriteByte(0x01);
            p.WriteBytesArray(client.EnableCrypt());
            p.WriteInt(0x01);
            p.WriteInt(0x01);
            return p;
        }
    }
}