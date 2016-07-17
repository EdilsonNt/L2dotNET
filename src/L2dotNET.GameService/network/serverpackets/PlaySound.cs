using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PlaySound
    {
        private const byte Opcode = 0x98;

        internal static Packet ToPacket(string file, int questShip1 = 0, int questShip2 = 0, int x = 0, int y = 0, int z = 0, bool ogg = false)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(ogg ? 1 : 0);
            p.WriteString(file);
            p.WriteInt(questShip1);// 0 for quest; 1 for ship;
            p.WriteInt(questShip2);// 0 for quest; objectId of ship
            p.WriteInt(x);
            p.WriteInt(y);
            p.WriteInt(z);
            return p;
        }
    }
}