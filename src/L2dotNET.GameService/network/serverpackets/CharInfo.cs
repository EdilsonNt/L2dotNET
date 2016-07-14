using L2dotNET.GameService.Model.Inventory;
using L2dotNET.GameService.Model.Npcs.Cubic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CharInfo
    {
        private const byte Opcode = 0x03;

        internal static Packet ToPacket(L2Player player)
        {
            Packet p = new Packet(Opcode);

            p.WriteInt(player.X, player.Y, player.Z);
            p.WriteInt(player.Heading, player.ObjId);
            p.WriteString(player.Name);

            p.WriteInt((int)player.BaseClass.ClassId.ClassRace);
            p.WriteInt(player.Sex);
            p.WriteInt((int)player.ActiveClass.ClassId.Id);

            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollHair]?.Template?.ItemId ?? 0);
            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollHead]?.Template?.ItemId ?? 0);
            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollRhand]?.Template?.ItemId ?? 0);
            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollLhand]?.Template?.ItemId ?? 0);
            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollGloves]?.Template?.ItemId ?? 0);
            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollChest]?.Template?.ItemId ?? 0);
            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollLegs]?.Template?.ItemId ?? 0);
            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollFeet]?.Template?.ItemId ?? 0);
            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollBack]?.Template?.ItemId ?? 0);
            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollRhand]?.Template?.ItemId ?? 0);
            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollHairall]?.Template?.ItemId ?? 0);
            p.WriteInt(player.Inventory.Paperdoll[Inventory.PaperdollFace]?.Template?.ItemId ?? 0);

            p.WriteShort(0x00, 0x00, 0x00, 0x00);
            p.WriteInt(0x00); //player.Inventory.getPaperdollAugmentId(InvPC.EQUIPITEM_RHand));
            p.WriteShort(0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);
            p.WriteInt(0x00); //player.Inventory.getPaperdollAugmentId(InvPC.EQUIPITEM_LHand));
            p.WriteShort(0x00, 0x00, 0x00, 0x00);

            p.WriteInt(player.PvPStatus, player.Karma);

            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.BAttackSpd)); //matkspeed
            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.BCastingSpd));

            p.WriteInt(player.PvPStatus);
            p.WriteInt(player.Karma);

            double spd = player.CharacterStat.GetStat(EffectType.PSpeed);
            double anim = (spd * 1f) / 130;
            double anim2 = (1.1 * player.CharacterStat.GetStat(EffectType.BAttackSpd)) / 300;
            double runSpd = spd / anim;
            double walkSpd = (spd * .8) / anim;

            p.WriteInt((int)runSpd);
            p.WriteInt((int)walkSpd);
            p.WriteInt(50); // swimspeed
            p.WriteInt(50); // swimspeed
            p.WriteInt((int)runSpd);
            p.WriteInt((int)walkSpd);
            p.WriteInt((int)runSpd);
            p.WriteInt((int)walkSpd);
            p.WriteDouble(anim);
            p.WriteDouble(anim2);

            p.WriteDouble(player.Radius);
            p.WriteDouble(player.Height);

            p.WriteInt(player.HairStyle);
            p.WriteInt(player.HairColor);
            p.WriteInt(player.Face);

            p.WriteString(player.Title);

            p.WriteInt(player.ClanId);
            p.WriteInt(player.ClanCrestId);
            p.WriteInt(player.AllianceId);
            p.WriteInt(player.AllianceCrestId);

            p.WriteInt(0);

            p.WriteByte(player.IsSitting() ? (byte)0x00 : (byte)0x01); // standing = 1  sitting = 0
            p.WriteByte(player.IsRunning);
            p.WriteByte(player.isInCombat() ? (byte)1 : (byte)0);
            p.WriteByte(player.IsAlikeDead() ? (byte)1 : (byte)0); //if (_activeChar.isInOlympiadMode()) 0 TODO
            p.WriteByte(player.Visible ? (byte)0 : (byte)1);

            p.WriteByte((byte)player.MountType);
            p.WriteByte(player.GetPrivateStoreType());

            p.WriteShort((short)player.Cubics.Count);
            foreach (Cubic cub in player.Cubics)
            {
                p.WriteShort((short)cub.Template.Id);
            }

            p.WriteByte(0x00); //1-_activeChar.isInPartyMatchRoom()

            p.WriteInt(player.AbnormalBitMask);

            p.WriteByte(0); //_activeChar.isFlyingMounted() ? 2 : 0);
            p.WriteShort((short)player.RecHave);
            p.WriteInt((int)player.ActiveClass.ClassId.Id);

            p.WriteInt(player.MaxCp); //max cp here
            p.WriteInt((int)player.CurCp);
            p.WriteInt(player.GetEnchantValue());
            p.WriteInt(player.TeamId);
            p.WriteInt(player.GetClanCrestLargeId());
            p.WriteInt(player.Noblesse);

            byte hero = player.Heroic;
            if (player.TransformId != 0)
            {
                hero = 0;
            }

            p.WriteByte(hero);

            p.WriteByte(player.IsFishing() ? (byte)0x01 : (byte)0x00); //Fishing Mode
            p.WriteInt(player.GetFishx()); //fishing x
            p.WriteInt(player.GetFishy()); //fishing y
            p.WriteInt(player.GetFishz()); //fishing z
            p.WriteInt(player.GetNameColor());

            p.WriteInt(0x00);

            p.WriteInt(player.ClanRank());
            p.WriteInt(player.ClanType);

            p.WriteInt(player.GetTitleColor());
            p.WriteInt(0x00); //titlecolor

            return p;
        }
    }
}