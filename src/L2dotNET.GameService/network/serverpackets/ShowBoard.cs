using System.Collections.Generic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Utility;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ShowBoard
    {
        private readonly string _id;
        private readonly string _htmlCode;
        private readonly List<string> _arg;
        private const short BbsMax = 8180;

        public ShowBoard(string htm, string id)
        {
            _id = id;
            _htmlCode = htm;
        }

        public ShowBoard(List<string> arg)
        {
            _id = "1002";
            _htmlCode = null;
            _arg = arg;
        }

        public static void SeparateAndSend(string html, L2Player player)
        {
            if (html.Length < BbsMax)
            {
                player.SendPacket(new ShowBoard(html, "101"));
                player.SendPacket(new ShowBoard(null, "102"));
                player.SendPacket(new ShowBoard(null, "103"));
            }
            else if (html.Length < (BbsMax * 2))
            {
                player.SendPacket(new ShowBoard(html.Remove(BbsMax), "101"));
                player.SendPacket(new ShowBoard(html.Substring(BbsMax), "102"));
                player.SendPacket(new ShowBoard(null, "103"));
            }
            else if (html.Length < (BbsMax * 3))
            {
                player.SendPacket(new ShowBoard(html.Remove(BbsMax), "101"));
                player.SendPacket(new ShowBoard(html.Substring(BbsMax).Remove(BbsMax), "102"));
                player.SendPacket(new ShowBoard(html.Substring(BbsMax * 2), "103"));
            }
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x6e);
            p.WriteInt(0x01); // c4 1 to show community 00 to hide
            p.WriteString("bypass _bbshome"); // top
            p.WriteString("bypass _bbsgetfav"); // favorite
            p.WriteString("bypass _bbsloc"); // region
            p.WriteString("bypass _bbsclan"); // clan
            p.WriteString("bypass _bbsmemo"); // memo
            p.WriteString("bypass _maillist_0_1_0_"); // mail
            p.WriteString("bypass _friendlist_0_"); // friends
            p.WriteString("bypass bbs_add_fav"); // add fav.

            string st = _id + "\u0008";
            if (!_id.EqualsIgnoreCase("1002"))
            {
                st += _htmlCode;
            }
            else
            {
                foreach (string s in _arg)
                {
                    st += s + " \u0008";
                }
            }

            p.WriteString(st);
        }
    }
}