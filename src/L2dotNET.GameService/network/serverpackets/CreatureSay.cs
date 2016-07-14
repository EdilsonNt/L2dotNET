using L2dotNET.GameService.Model.Player.Basic;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CreatureSay
    {
        private const byte Opcode = 0x4a;

        internal static Packet ToPacket(int id, SayIDList type, string name, string text)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(id);
            p.WriteInt((int)type);
            p.WriteString(name);
            p.WriteString(text);
            return p;
        }
    }
}