using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestUnEquipItem : PacketBase
    {
        public RequestUnEquipItem(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        private int _slotBitType;

        public override void Read()
        {
            _slotBitType = ReadD();
        }

        public override void RunImpl()
        {
            L2Player player = GetClient().CurrentPlayer;

            if (player.PBlockAct == 1)
            {
                player.SendActionFailed();
                return;
            }

            //int dollId = player.Inventory.getPaperdollIdByMask(slotBitType);

            //player.setPaperdoll(dollId, null, true);
            player.BroadcastUserInfo();
        }
    }
}