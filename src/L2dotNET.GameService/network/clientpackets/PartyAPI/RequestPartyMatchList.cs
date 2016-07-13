using log4net;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets.PartyAPI
{
    class RequestPartyMatchList : PacketBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RequestPartyMatchList));

        public RequestPartyMatchList(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        private int _status;

        public override void Read()
        {
            _status = ReadD();
        }

        public override void RunImpl()
        {
            Log.Info($"party {_status}");
        }
    }
}