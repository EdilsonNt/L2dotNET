using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestRestart : PacketBase
    {
        public RequestRestart(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        public override void Read()
        {
            // do nothing
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            if (player.PBlockAct == 1)
            {
                player.SendActionFailed();
                return;
            }

            if (player.isInCombat())
            {
                player.SendSystemMessage(SystemMessage.SystemMessageId.CantRestartWhileFighting);
                player.SendActionFailed();
                return;
            }

            player.Termination();
            player.SendPacket(new RestartResponse());

            CharacterSelectionInfo csl = new CharacterSelectionInfo(Client.AccountName, Client.AccountChars, Client.SessionId)
                                         {
                                             CharId = player.ObjId
                                         };
            player.SendPacket(csl);
        }
    }
}