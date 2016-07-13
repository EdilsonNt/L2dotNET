using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestDispel : PacketBase
    {
        private int _ownerId;
        private int _skillId;
        private int _skillLv;

        public RequestDispel(Packet packet, GameClient client)
        {
            Makeme(client, data, 2);
        }

        public override void Read()
        {
            _ownerId = ReadD();
            _skillId = ReadD();
            _skillLv = ReadD();
        }

        public override void RunImpl()
        {
            L2Player player = Client.CurrentPlayer;

            if (_ownerId != player.ObjId)
            {
                player.SendActionFailed();
                return;
            }

            AbnormalEffect avestop = null;
            foreach (AbnormalEffect ave in player.Effects)
            {
                if ((ave.Id != _skillId) && (ave.Lvl != _skillLv))
                {
                    continue;
                }

                if ((ave.Skill.Debuff == 1) && (ave.Skill.IsMagic > 1))
                {
                    break;
                }

                avestop = ave;
                break;
            }

            if (avestop == null)
            {
                player.SendActionFailed();
                return;
            }

            lock (player.Effects)
            {
                avestop.ForcedStop(true, true);
                player.Effects.Remove(avestop);
            }
        }
    }
}