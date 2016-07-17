using L2dotNET.GameService.Model.Inventory;
using L2dotNET.GameService.Model.Npcs.Cubic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class UserInfo
    {
        private const byte Opcode = 0x04;

        //TODO: Simplify method body
        internal static Packet ToPacket(L2Player player)
        {
            Packet p = new Packet(Opcode);

            p.WriteInt(player.X, player.Y, player.Z);
            p.WriteInt(player.Heading, player.ObjId);

            p.WriteString(player.Name);

            p.WriteInt((int)player.BaseClass.ClassId.ClassRace);
            p.WriteInt(player.Sex);
            p.WriteInt((int)player.BaseClass.ClassId.Id);
            p.WriteInt(player.Level);
            p.WriteLong(player.Exp);

            p.WriteInt(player.Str);
            p.WriteInt(player.Dex);
            p.WriteInt(player.Con);
            p.WriteInt(player.Int);
            p.WriteInt(player.Wit);
            p.WriteInt(player.Men);

            p.WriteInt(player.MaxHp); //max hp
            p.WriteInt((int)player.CurHp);
            p.WriteInt(player.MaxMp); //max mp
            p.WriteInt((int)player.CurMp);
            p.WriteInt(player.Sp);
            p.WriteInt(player.CurrentWeight);
            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.BMaxWeight));

            p.WriteInt(player.Inventory.GetPaperdollItem(Inventory.PaperdollRhand) != null ? 40 : 20); // 20 no weapon, 40 weapon equipped

            for (byte id = 0; id < Inventory.PaperdollTotalslots; id++)
            {
                    p.WriteInt(player.Inventory.Paperdoll[id]?.Template?.ItemId ?? 0);
            }

            for (byte id = 0; id < Inventory.PaperdollTotalslots; id++)
            {
                    p.WriteInt(player.Inventory.Paperdoll[id]?.Template?.ItemId ?? 0);
            }

            // c6 new h's
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

            double atkspd = player.CharacterStat.GetStat(EffectType.BAttackSpd);
            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.PPhysicalAttack));
            p.WriteInt((int)atkspd);
            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.PPhysicalDefense));
            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.BEvasion));
            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.BAccuracy));
            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.BCriticalRate));
            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.PMagicalAttack));
            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.BCastingSpd));
            p.WriteInt((int)atkspd); //? еще раз?
            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.PMagicalDefense));

            p.WriteInt(player.PvPStatus);
            p.WriteInt(player.Karma);

            double spd = player.CharacterStat.GetStat(EffectType.PSpeed);

            double anim = (spd * 1f) / 130;
            //double anim2 = (1.1) * atkspd / 300;
            double runSpd = spd / anim;
            double walkSpd = (spd * .8) / anim;

            p.WriteInt((int)runSpd);
            p.WriteInt((int)walkSpd);
            p.WriteInt(50); // swimspeed
            p.WriteInt(50); // swimspeed
            p.WriteInt(0); //?
            p.WriteInt(0); //?
            p.WriteInt((int)runSpd); //fly run
            p.WriteInt((int)walkSpd); //fly walk ?
            p.WriteDouble(1); //run speed multiplier
            p.WriteDouble(1); //atk speed multiplier

            p.WriteDouble(player.Radius);
            p.WriteDouble(player.Height);

            p.WriteInt(player.HairStyle);
            p.WriteInt(player.HairColor);
            p.WriteInt(player.Face);
            p.WriteInt(player.Builder);

            p.WriteString(player.Title);

            p.WriteInt(player.ClanId);
            p.WriteInt(player.ClanCrestId);
            p.WriteInt(player.AllianceId);
            p.WriteInt(player.AllianceCrestId);

            p.WriteInt(player.Sstt); //_relation
            p.WriteByte((byte)player.MountType);
            p.WriteByte(player.GetPrivateStoreType()); //
            p.WriteByte(player.PCreateItem > 0 ? (byte)1 : (byte)0);
            p.WriteInt(player.PkKills);
            p.WriteInt(player.PvpKills);

            p.WriteShort((short)player.Cubics.Count);
            foreach (Cubic cub in player.Cubics)
            {
                p.WriteShort((short)cub.Template.Id);
            }

            p.WriteByte(0); //1-isInPartyMatchRoom

            p.WriteInt(player.AbnormalBitMask);

            //byte flymode = 0;

            //if (player.TransformID > 0)
            //    flymode = player.Transform.Template.MoveMode;

            p.WriteByte(0x00);

            p.WriteInt(player.ClanPrivs);

            p.WriteShort((short)player.RecHave); //c2  recommendations remaining
            p.WriteShort((short)player.RecLeft); //c2  recommendations received
            p.WriteInt(player.MountType > 0 ? player.MountedTemplate.NpcId + 1000000 : 0); //moun t npcid
            p.WriteShort((short)player.ItemLimitInventory);

            p.WriteInt((int)player.ActiveClass.ClassId.Id);
            p.WriteInt(0); // special effects? circles around player...
            p.WriteInt(player.MaxCp); //max cp
            p.WriteInt((int)player.CurCp);
            p.WriteByte(player.GetEnchantValue());
            p.WriteByte((byte)player.TeamId);
            p.WriteInt(player.GetClanCrestLargeId());
            p.WriteByte(player.Noblesse);

            byte hero = player.Heroic;
            p.WriteByte(hero);

            p.WriteByte(player.IsFishing() ? (byte)0x01 : (byte)0x00); //Fishing Mode
            p.WriteInt(player.GetFishx()); //fishing x
            p.WriteInt(player.GetFishy()); //fishing y
            p.WriteInt(player.GetFishz()); //fishing z
            p.WriteInt(player.GetNameColor());

            p.WriteByte(player.IsRunning);

            p.WriteInt(player.ClanRank());
            p.WriteInt(player.ClanType);

            p.WriteInt(player.GetTitleColor());
            p.WriteInt(player.CursedWeaponLevel);
            return p;
        }
    }
}