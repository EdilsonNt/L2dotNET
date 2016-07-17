using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Tables;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class NpcHtmlMessage
    {

        private const byte Opcode = 0x0f;

        internal static Packet ToPacket(L2Player player, string file, int objId, int itemId = 0, bool acceptText = false)
        {
            string html = acceptText ? "<html><body>" + file + "</body></html>" : HtmCache.Instance.GetHtmByFilename(file);
            Packet p = new Packet(Opcode);
            p.WriteInt(objId);
            p.WriteString(html);
            p.WriteInt(itemId);
            return p;
        }

    }
}