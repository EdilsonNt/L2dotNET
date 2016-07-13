using System.Collections.Generic;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestManorList : PacketBase
    {
        public RequestManorList(Packet packet, GameClient client)
        {
            Makeme(client, data, 2);
        }

        public override void Read()
        {
            // do nothing
        }

        public override void RunImpl()
        {
            List<string> manorsName = new List<string>
                                      {
                                          "gludio",
                                          "dion",
                                          "giran",
                                          "oren",
                                          "aden",
                                          "innadril",
                                          "goddard",
                                          "rune",
                                          "schuttgart"
                                      };
            GetClient().SendPacket(new ExSendManorList(manorsName));
        }
    }
}