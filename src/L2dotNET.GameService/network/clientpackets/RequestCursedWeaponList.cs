using L2dotNET.GameService.Config;
using L2dotNET.GameService.Model.Items.Cursed;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class RequestCursedWeaponList : PacketBase
    {
        public RequestCursedWeaponList(Packet packet, GameClient client)
        {
            Makeme(client, data, 2);
        }

        public override void Read()
        {
            // nothing
        }

        public override void RunImpl()
        {
            int[] ids = CursedWeapons.GetInstance().GetWeaponIds();

            Client.SendPacket(new ExCursedWeaponList(ids));
        }
    }
}