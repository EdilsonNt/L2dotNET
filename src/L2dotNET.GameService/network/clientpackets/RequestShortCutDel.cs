using System.Linq;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Player.General;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestShortCutDel : PacketBase
    {
        public RequestShortCutDel(Packet packet, GameClient client)
        {
            Makeme(client, data);
        }

        private int _slot;
        private int _page;

        public override void Read()
        {
            int id = ReadD();
            _slot = id % 12;
            _page = id / 12;
        }

        public override void RunImpl()
        {
            L2Player player = GetClient().CurrentPlayer;

            L2Shortcut scx = player.Shortcuts.FirstOrDefault(sc => (sc.Slot == _slot) && (sc.Page == _page));

            if (scx == null)
            {
                player.SendActionFailed();
                return;
            }

            lock (player.Shortcuts)
            {
                player.Shortcuts.Remove(scx);

                //SQL_Block sqb = new SQL_Block("user_shortcuts");
                //sqb.where("ownerId", player.ObjID);
                //sqb.where("classId", player.ActiveClass.id);
                //sqb.where("slot", _slot);
                //sqb.where("page", _page);
                //sqb.sql_delete(false);
            }

            player.SendPacket(new ShortCutInit(player));
        }
    }
}