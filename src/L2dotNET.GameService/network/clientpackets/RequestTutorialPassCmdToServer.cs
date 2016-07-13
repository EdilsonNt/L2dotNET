﻿using L2dotNET.GameService.Handlers;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Utility;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestTutorialPassCmdToServer : GameServerNetworkRequest
    {
        public RequestTutorialPassCmdToServer(GameClient client, byte[] data)
        {
            Makeme(client, data);
        }

        private string _alias;

        public override void Read()
        {
            _alias = ReadS();
            if (_alias.Contains("\n"))
            {
                _alias = _alias.Replace("\n", "");
            }
        }

        public override void Run()
        {
            L2Player player = GetClient().CurrentPlayer;

            if (player.PBlockAct == 1)
            {
                player.SendActionFailed();
                return;
            }

            if (_alias.StartsWithIgnoreCase("menu_select?"))
            {
                //_alias = _alias.Replace(" ", "");
                //string x1 = _alias.Split('?')[1];
                //string[] x2 = x1.Split('&');
                //int ask = int.Parse(x2[0].Substring(4));
                //int reply = int.Parse(x2[1].Substring(6));

                //  npc.onDialog(player, ask, reply);
            }
            else if (_alias.StartsWithIgnoreCase("admin?"))
            {
                if (player.ViewingAdminPage == 0)
                {
                    player.SendActionFailed();
                    return;
                }

                if (_alias.Contains("tp"))
                {
                    string[] coord = _alias.Split(' ');
                    int x,
                        y,
                        z;
                    if (!int.TryParse(coord[1], out x) || !int.TryParse(coord[2], out y) || !int.TryParse(coord[3], out z))
                    {
                        player.SendMessage("Only numbers allowed in box.");
                        return;
                    }

                    AdminCommandHandler.Instance.ProcessBypassTp(player, x, y, z);
                }
                else
                {
                    string x1 = _alias.Split('?')[1];
                    string[] x2 = x1.Split('&');
                    int ask = int.Parse(x2[0].Substring(4));
                    int reply = int.Parse(x2[1].Substring(6));

                    AdminCommandHandler.Instance.ProcessBypass(player, ask, reply);
                }
            }
        }
    }
}