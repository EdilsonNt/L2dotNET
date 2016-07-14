using System.Collections.Generic;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ExReplyDominionInfo
    {
        private readonly List<string> _names = new List<string>();

        public ExReplyDominionInfo()
        {
            _names.Add("gludio");
            _names.Add("dion");
            _names.Add("giran");
            _names.Add("oren");
            _names.Add("aden");
            _names.Add("innadril");
            _names.Add("goddard");
            _names.Add("rune");
            _names.Add("schuttgart");
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xfe);
            p.WriteShort(0x92);
            p.WriteInt(_names.Count);

            byte x = 81;
            foreach (string str in _names)
            {
                p.WriteInt(x); // Territory Id
                p.WriteString(str + "_dominion"); // territory name
                p.WriteString("");
                p.WriteInt(0); // Emblem Count
                //  for(int i:t.getOwnedWardIds())
                //    p.WriteInt(i); // Emblem ID - should be in for loop for emblem count
                p.WriteInt(0);

                x++;
            }
        }
    }
}