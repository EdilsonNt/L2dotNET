using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharacterSelected
    {
        private const byte Opcode = 0x15;

        internal static Packet ToPacket(L2Player player, int session)
        {
            Packet p = new Packet(Opcode);

            p.WriteString(player.Name);
            p.WriteInt(player.ObjId);
            p.WriteString(player.Title);
            p.WriteInt(session);

            p.WriteInt(player.ClanId);
            p.WriteInt(0x00); //??
            p.WriteInt(player.Sex, (int)player.BaseClass.ClassId.ClassRace, (int)player.ActiveClass.ClassId.Id);
            p.WriteInt(0x01); // active ??
            p.WriteInt(player.X, player.Y, player.Z);
            p.WriteDouble(player.CurHp, player.CurMp);
            p.WriteInt(player.Sp);

            p.WriteLong(player.Exp);
            p.WriteInt(player.Level, player.Karma); // thx evill33t
            p.WriteInt(0); //?

            p.WriteInt(player.Int, player.Str, player.Con, player.Men, player.Dex, player.Wit);

            for (int i = 0; i < 30; i++)
            {
                p.WriteInt(0x00);
            }

            p.WriteInt(0x00); // c3 work
            p.WriteInt(0x00); // c3 work

            p.WriteInt(0x00);

            p.WriteInt(0x00); // c3

            p.WriteInt((int)player.ActiveClass.ClassId.Id);

            p.WriteInt(0x00); // c3 InspectorBin
            p.WriteInt(0x00); // c3
            p.WriteInt(0x00); // c3
            p.WriteInt(0x00); // c3
            return p;
        }
    }
}