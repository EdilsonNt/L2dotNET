using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestSocialAction : PacketBase
    {
        private int _actionId;

        public RequestSocialAction(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        public override void Read()
        {
            _actionId = ReadD();
        }

        public override void RunImpl()
        {
            L2Player player = GetClient().CurrentPlayer;
            if (player == null)
            {
                return;
            }

            if ((_actionId < 2) || (_actionId > 13))
            {
                return;
            }

            player.BroadcastPacket(new SocialAction(player.ObjId, _actionId));
        }
    }
}