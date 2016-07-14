using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExBrExtraUserInfo
    {
        private const short Opcode = 0xcf;

        internal static Packet ToPacket(int id, int value)
        {
            Packet p = new Packet(0xFE);
            p.WriteShort(Opcode);
            p.WriteInt(id);
            p.WriteInt(value); // event effect id
            //p.WriteInt(0x00);		// Event flag, added only if event is active
            return p;
        }
    }
}