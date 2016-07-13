﻿using System;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class ValidatePosition : PacketBase
    {
        public ValidatePosition(Packet packet, GameClient client)
        {
            _client = client;
        }

        private const int Synctype = 1;

        private int _x;
        private int _y;
        private int _z;
        private int _heading;
        private int _data;

        public override void Read()
        {
            _x = packet.ReadInt();
            _y = packet.ReadInt();
            _z = packet.ReadInt();
            _heading = packet.ReadInt();
            _data = packet.ReadInt();
        }

        public override void RunImpl()
        {
            L2Player player = GetClient().CurrentPlayer;
            //string prevReg = player.CurrentRegion;

            int realX = player.X;
            int realY = player.Y;
            //int realZ = player.Z;

            int dx = _x - realX;
            int dy = _y - realY;
            //int dz = _z - realZ;
            double diffSq = (dx * dx) + (dy * dy);

            if (diffSq < 360000)
            {
                if (!player.IsMoving())
                {
                    if (diffSq < 2500)
                    {
                        player.X = realX;
                        player.Y = realY;
                        player.Z = _z;
                    }
                    else
                    {
                        player.X = _x;
                        player.Y = _y;
                        player.Z = _z;
                    }
                }
                Console.WriteLine($"Current position: X:{player.X}, Y:{player.Y}, Z:{player.Z}"); //debug
                player.BroadcastUserInfo();
                return;
            }

            player.X = _x;
            player.Y = _y;
            player.Z = _z;
            player.Heading = _heading;
            Console.WriteLine($"Current position: X:{player.ClientPosX}, Y:{player.ClientPosY}, Z:{player.ClientPosZ}"); //debug
            player.BroadcastUserInfo();
            //player.validateVisibleObjects(_x, _y, true);
        }
    }
}