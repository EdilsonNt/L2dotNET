﻿using L2dotNET.Network;

namespace L2dotNET.LoginService.Network.OuterNetwork.ServerPackets
{
    /// <summary>
    /// Play accepted packet.
    /// </summary>
    static class PlayOk
    {
        /// <summary>
        /// Packet opcode.
        /// </summary>
        private const byte Opcode = 0x07;

        /// <summary>
        /// Returns play accepted server > client packet.
        /// </summary>
        /// <param name="client"><see cref="LoginClient"/> object.</param>
        /// <returns>Play accepted <see cref="Packet"/>.</returns>
        internal static Packet ToPacket(LoginClient client)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(client.Play1, client.Play2);
            return p;
        }
    }
}