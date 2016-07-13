﻿using L2dotNET.Network;

namespace L2dotNET.LoginService.Network.OuterNetwork.ServerPackets
{
    static class Init
    {
        /// <summary>
        /// Packet opcode.
        /// </summary>
        private const byte Opcode = 0x00;

        internal static Packet ToPacket(LoginClient client)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(client.SessionId, 0x0000c621);
            p.WriteBytesArray(client.RsaPair._scrambledModulus);
            p.WriteInt(0x29DD954E, 0x77C39CFC, unchecked((int)0x97ADB620), 0x07BDE0F7);
            p.WriteBytesArray(client.BlowfishKey);
            p.WriteByte(0x00);
            return p;
        }
    }
}