using System;
using L2dotNET.GameService.World;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ChangeMoveType
    {
        private const byte Opcode = 0x2e;
        private const int Walk = 0;
        private const int Run = 1;

        internal static Packet ToPacket(L2Character character)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(character.ObjId, Convert.ToBoolean(character.IsRunning) ? Run : Walk);
            p.WriteByte(0); // c2
            return p;
        }
    }
}