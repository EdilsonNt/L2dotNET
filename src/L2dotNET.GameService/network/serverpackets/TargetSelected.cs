using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class TargetSelected
    {
        private const byte Opcode = 0x29;
        
        internal static Packet ToPacket(int objectId, int targetId, int x, int y, int z)
        {
            Packet p =  new Packet(Opcode);
            p.WriteInt(objectId);
            p.WriteInt(targetId);
            p.WriteInt(x);
            p.WriteInt(y);
            p.WriteInt(z);
            return p;
        }
    }
}