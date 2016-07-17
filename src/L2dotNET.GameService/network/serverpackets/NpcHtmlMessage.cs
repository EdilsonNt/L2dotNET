using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Tables;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class NpcHtmlMessage
    {

        private const byte Opcode = 0x0f;

        internal Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(_objId);
            p.WriteString(Htm);
            p.WriteInt(_itemId);
            return p;
        }
        public static string Htm;
        private static int _objId;
        private static int _itemId;

        public NpcHtmlMessage(L2Player player, string file, int objId)
        {
            Htm = HtmCache.Instance.GetHtmByFilename(file);
            _objId = objId;
            _itemId = 0;
        }

        public NpcHtmlMessage(L2Player player, string file, int objId, int itemId)
        {
            Htm = HtmCache.Instance.GetHtmByFilename(file);
            _objId = objId;
            _itemId = itemId;
        }

        public NpcHtmlMessage(L2Player player, string plain, int objId, bool isPlain)
        {
            Htm = "<html><body>" + plain + "</body></html>";
            _objId = objId;
            _itemId = 0;
        }

        public void Replace(string p, object t)
        {
            Htm = Htm.Replace(p, t.ToString());
        }

    }
}