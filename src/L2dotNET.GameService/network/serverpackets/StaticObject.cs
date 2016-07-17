using L2dotNET.GameService.Model.Npcs.Decor;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class StaticObject
    {
        private const byte Opcode = 0x99;

        internal static Packet ToPacket(L2StaticObject obj)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(obj.StaticId);
            p.WriteInt(obj.ObjId);
            return p;
        }
    }
}