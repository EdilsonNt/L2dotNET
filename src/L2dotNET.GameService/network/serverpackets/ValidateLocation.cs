using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ValidateLocation
    {
        private const byte Opcode = 0x61;

        internal static Packet ToPacket(L2Character character)
        {
            Packet p = new Packet(Opcode);

            p.WriteInt(character.ObjId);
            p.WriteInt(character.X);
            p.WriteInt(character.Y);
            p.WriteInt(character.Z);
            p.WriteInt(character.Heading);
            return p;
        }
    }
}