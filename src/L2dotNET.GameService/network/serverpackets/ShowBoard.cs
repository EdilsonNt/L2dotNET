using System;
using System.Collections.Generic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;
using L2dotNET.Utility;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ShowBoard
    {
        private const byte Opcode = 0x6e;
        //public static readonly ShowBoard StaticShowboard102 = ToPacket(null, "102");
        //public static readonly ShowBoard StaticShowboard103 = new ShowBoard(null, "103");

        private static readonly string Top = "bypass _bbshome";
	    private static readonly string Fav = "bypass _bbsgetfav";
	    private static readonly string Region = "bypass _bbsloc";
	    private static readonly string Clan = "bypass _bbsclan";
	    private static readonly string Memo = "bypass _bbsmemo";
	    private static readonly string Mail = "bypass _maillist_0_1_0_";
	    private static readonly string Friends = "bypass _friendlist_0_";
	    private static readonly string Addfav = "bypass bbs_add_fav";

        private const short BbsMax = 8180;

        //public ShowBoard(List<string> arg)
        //{
        //    _id = "1002\u0008";
        //    _htmlCode = null;
        //    _arg = arg;
        //}

        public static void SeparateAndSend(string html, L2Player player)
        {
            if (html.Length < BbsMax)
            {
                player.SendPacket(ToPacket(html, "101"));
                player.SendPacket(ToPacket(null, "102"));
                player.SendPacket(ToPacket(null, "103"));
            }
            else if (html.Length < (BbsMax * 2))
            {
                player.SendPacket(ToPacket(html.Remove(BbsMax), "101"));
                player.SendPacket(ToPacket(html.Substring(BbsMax), "102"));
                player.SendPacket(ToPacket(null, "103"));
            }
            else if (html.Length < (BbsMax * 3))
            {
                player.SendPacket(ToPacket(html.Remove(BbsMax), "101"));
                player.SendPacket(ToPacket(html.Substring(BbsMax).Remove(BbsMax), "102"));
                player.SendPacket(ToPacket(html.Substring(BbsMax * 2), "103"));
            }
        }

        internal static Packet ToPacket(string htm, string id, List<string> arg = null)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0x01); // c4 1 to show community 00 to hide
            p.WriteString(Top); // top
            p.WriteString(Fav); // favorite
            p.WriteString(Region); // region
            p.WriteString(Clan); // clan
            p.WriteString(Memo); // memo
            p.WriteString(Mail); // mail
            p.WriteString(Friends); // friends
            p.WriteString(Addfav); // add fav.

            string st = id + "\u0008";
            if (!id.EqualsIgnoreCase("1002"))
            {
                st += htm;
            }
            else
            {
                foreach (string s in arg)
                {
                    st += s + " \u0008";
                }
            }

            p.WriteString(st);
            return p;
        }
    }
}