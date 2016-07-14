using L2dotNET.GameService.Model.Inventory;
using L2dotNET.GameService.Model.Npcs.Cubic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharInfo
    {
        private readonly L2Player _player;

        public CharInfo(L2Player player)
        {
            _player = player;
        }

        //TODO: Simplify method body
        internal static Packet ToPacket()
        {
            p.WriteInt(0x03);

            p.WriteInt(_player.X);
            p.WriteInt(_player.Y);
            p.WriteInt(_player.Z);
            p.WriteInt(_player.Heading);
            p.WriteInt(_player.ObjId);
            p.WriteString(_player.Name);

            p.WriteInt((int)_player.BaseClass.ClassId.ClassRace);
            p.WriteInt(_player.Sex);
            p.WriteInt((int)_player.ActiveClass.ClassId.Id);

            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollHair]?.Template?.ItemId ?? 0);
            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollHead]?.Template?.ItemId ?? 0);
            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollRhand]?.Template?.ItemId ?? 0);
            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollLhand]?.Template?.ItemId ?? 0);
            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollGloves]?.Template?.ItemId ?? 0);
            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollChest]?.Template?.ItemId ?? 0);
            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollLegs]?.Template?.ItemId ?? 0);
            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollFeet]?.Template?.ItemId ?? 0);
            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollBack]?.Template?.ItemId ?? 0);
            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollRhand]?.Template?.ItemId ?? 0);
            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollHairall]?.Template?.ItemId ?? 0);
            p.WriteInt(_player.Inventory.Paperdoll[Inventory.PaperdollFace]?.Template?.ItemId ?? 0);

            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteInt(0x00); //player.Inventory.getPaperdollAugmentId(InvPC.EQUIPITEM_RHand));
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteInt(0x00); //player.Inventory.getPaperdollAugmentId(InvPC.EQUIPITEM_LHand));
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);
            p.WriteShort(0x00);

            p.WriteInt(_player.PvPStatus);
            p.WriteInt(_player.Karma);

            p.WriteInt(_player.CharacterStat.GetStat(EffectType.BAttackSpd)); //matkspeed
            p.WriteInt(_player.CharacterStat.GetStat(EffectType.BCastingSpd));

            p.WriteInt(_player.PvPStatus);
            p.WriteInt(_player.Karma);

            double spd = _player.CharacterStat.GetStat(EffectType.PSpeed);
            double anim = (spd * 1f) / 130;
            double anim2 = (1.1 * _player.CharacterStat.GetStat(EffectType.BAttackSpd)) / 300;
            double runSpd = spd / anim;
            double walkSpd = (spd * .8) / anim;

            p.WriteInt(runSpd);
            p.WriteInt(walkSpd);
            p.WriteInt(50); // swimspeed
            p.WriteInt(50); // swimspeed
            p.WriteInt(runSpd);
            p.WriteInt(walkSpd);
            p.WriteInt(runSpd);
            p.WriteInt(walkSpd);
            p.WriteDouble(anim);
            p.WriteDouble(anim2);

            p.WriteDouble(_player.Radius);
            p.WriteDouble(_player.Height);

            p.WriteInt(_player.HairStyle);
            p.WriteInt(_player.HairColor);
            p.WriteInt(_player.Face);

            p.WriteString(_player.Title);

            p.WriteInt(_player.ClanId);
            p.WriteInt(_player.ClanCrestId);
            p.WriteInt(_player.AllianceId);
            p.WriteInt(_player.AllianceCrestId);

            p.WriteInt(0);

            p.WriteInt(_player.IsSitting() ? 0 : 1); // standing = 1  sitting = 0
            p.WriteInt(_player.IsRunning);
            p.WriteInt(_player.isInCombat() ? 1 : 0);
            p.WriteInt(_player.IsAlikeDead() ? 1 : 0); //if (_activeChar.isInOlympiadMode()) 0 TODO
            p.WriteInt(_player.Visible ? 0 : 1);

            p.WriteInt(_player.MountType);
            p.WriteInt(_player.GetPrivateStoreType());

            p.WriteShort(_player.Cubics.Count);
            foreach (Cubic cub in _player.Cubics)
            {
                p.WriteShort(cub.Template.Id);
            }

            p.WriteInt(0x00); //1-_activeChar.isInPartyMatchRoom()

            p.WriteInt(_player.AbnormalBitMask);

            p.WriteInt(0); //_activeChar.isFlyingMounted() ? 2 : 0);
            p.WriteShort(_player.RecHave);
            p.WriteInt((int)_player.ActiveClass.ClassId.Id);

            p.WriteInt(_player.MaxCp); //max cp here
            p.WriteInt((int)_player.CurCp);
            p.WriteInt(_player.GetEnchantValue());
            p.WriteInt(_player.TeamId);
            p.WriteInt(_player.GetClanCrestLargeId());
            p.WriteInt(_player.Noblesse);

            byte hero = _player.Heroic;
            if (_player.TransformId != 0)
            {
                hero = 0;
            }

            p.WriteInt(hero);

            p.WriteInt(_player.IsFishing() ? 0x01 : 0x00); //Fishing Mode
            p.WriteInt(_player.GetFishx()); //fishing x
            p.WriteInt(_player.GetFishy()); //fishing y
            p.WriteInt(_player.GetFishz()); //fishing z
            p.WriteInt(_player.GetNameColor());

            p.WriteInt(0x00);

            p.WriteInt(_player.ClanRank());
            p.WriteInt(_player.ClanType);

            p.WriteInt(_player.GetTitleColor());
            p.WriteInt(0x00); //titlecolor
        }
    }
}