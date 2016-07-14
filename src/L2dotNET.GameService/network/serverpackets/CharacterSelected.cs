using L2dotNET.GameService.Model.Player;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharacterSelected
    {
        private readonly int _session;
        private readonly L2Player _player;

        public CharacterSelected(L2Player player, int session)
        {
            _player = player;
            _session = session;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x15);

            p.WriteString(_player.Name);
            p.WriteInt(_player.ObjId);
            p.WriteString(_player.Title);
            p.WriteInt(_session);

            p.WriteInt(_player.ClanId);
            p.WriteInt(0x00); //??
            p.WriteInt(_player.Sex);
            p.WriteInt((int)_player.BaseClass.ClassId.ClassRace);

            p.WriteInt((int)_player.ActiveClass.ClassId.Id);
            p.WriteInt(0x01); // active ??
            p.WriteInt(_player.X);
            p.WriteInt(_player.Y);

            p.WriteInt(_player.Z);
            p.WriteDouble(_player.CurHp);
            p.WriteDouble(_player.CurMp);
            p.WriteInt(_player.Sp);

            p.WriteInt(_player.Exp);
            p.WriteInt(_player.Level);
            p.WriteInt(_player.Karma); // thx evill33t
            p.WriteInt(0); //?

            p.WriteInt(_player.Int);
            p.WriteInt(_player.Str);
            p.WriteInt(_player.Con);
            p.WriteInt(_player.Men);

            p.WriteInt(_player.Dex);
            p.WriteInt(_player.Wit);
            for (int i = 0; i < 30; i++)
            {
                p.WriteInt(0x00);
            }

            p.WriteInt(0x00); // c3 work
            p.WriteInt(0x00); // c3 work

            p.WriteInt(0x00);

            p.WriteInt(0x00); // c3

            p.WriteInt((int)_player.ActiveClass.ClassId.Id);

            p.WriteInt(0x00); // c3 InspectorBin
            p.WriteInt(0x00); // c3
            p.WriteInt(0x00); // c3
            p.WriteInt(0x00); // c3
        }
    }
}