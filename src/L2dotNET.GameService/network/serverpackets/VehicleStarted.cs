using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class VehicleStarted
    {
        private const byte Opcode = 0xBA;

        internal static Packet ToPacket(int sId, int type)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(sId);
            p.WriteInt(type);
            return p;
        }
    }
}