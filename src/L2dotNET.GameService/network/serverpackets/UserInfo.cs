using L2dotNET.GameService.Model.Inventory;
using L2dotNET.GameService.Model.Npcs.Cubic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class UserInfo
    {
        private readonly L2Player _player;

        public UserInfo(L2Player player)
        {
            _player = player;
        }

        //TODO: Simplify method body
        internal static Packet ToPacket()
        {
            p.WriteInt(0x04);

            p.WriteInt(_player.X);
            p.WriteInt(_player.Y);
            p.WriteInt(_player.Z);
            p.WriteInt(_player.Heading);
            p.WriteInt(_player.ObjId);

            p.WriteString(_player.Name);

            p.WriteInt((int)_player.BaseClass.ClassId.ClassRace);
            p.WriteInt(_player.Sex);
            p.WriteInt((int)_player.BaseClass.ClassId.Id);
            p.WriteInt(_player.Level);
            p.WriteInt(_player.Exp);

            p.WriteInt(_player.Str);
            p.WriteInt(_player.Dex);
            p.WriteInt(_player.Con);
            p.WriteInt(_player.Int);
            p.WriteInt(_player.Wit);
            p.WriteInt(_player.Men);

            p.WriteInt(_player.CurHp); //max hp
            p.WriteInt(_player.CurHp);
            p.WriteInt(_player.CurMp); //max mp
            p.WriteInt(_player.CurMp);
            p.WriteInt(_player.Sp);
            p.WriteInt(_player.CurrentWeight);
            p.WriteInt(_player.CharacterStat.GetStat(EffectType.BMaxWeight));

            p.WriteInt(_player.Inventory.GetPaperdollItem(Inventory.PaperdollRhand) != null ? 40 : 20); // 20 no weapon, 40 weapon equipped

            for (byte id = 0; id < Inventory.PaperdollTotalslots; id++)
            {
                    p.WriteInt(_player.Inventory.Paperdoll[id]?.Template?.ItemId ?? 0);
            }

            for (byte id = 0; id < Inventory.PaperdollTotalslots; id++)
            {
                    p.WriteInt(_player.Inventory.Paperdoll[id]?.Template?.ItemId ?? 0);
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

            double atkspd = _player.CharacterStat.GetStat(EffectType.BAttackSpd);
            p.WriteInt(_player.CharacterStat.GetStat(EffectType.PPhysicalAttack));
            p.WriteInt(atkspd);
            p.WriteInt(_player.CharacterStat.GetStat(EffectType.PPhysicalDefense));
            p.WriteInt(_player.CharacterStat.GetStat(EffectType.BEvasion));
            p.WriteInt(_player.CharacterStat.GetStat(EffectType.BAccuracy));
            p.WriteInt(_player.CharacterStat.GetStat(EffectType.BCriticalRate));
            p.WriteInt(_player.CharacterStat.GetStat(EffectType.PMagicalAttack));
            p.WriteInt(_player.CharacterStat.GetStat(EffectType.BCastingSpd));
            p.WriteInt(atkspd); //? еще раз?
            p.WriteInt(_player.CharacterStat.GetStat(EffectType.PMagicalDefense));

            p.WriteInt(_player.PvPStatus);
            p.WriteInt(_player.Karma);

            double spd = _player.CharacterStat.GetStat(EffectType.PSpeed);

            double anim = (spd * 1f) / 130;
            //double anim2 = (1.1) * atkspd / 300;
            double runSpd = spd / anim;
            double walkSpd = (spd * .8) / anim;

            p.WriteInt(runSpd);
            p.WriteInt(walkSpd);
            p.WriteInt(50); // swimspeed
            p.WriteInt(50); // swimspeed
            p.WriteInt(0); //?
            p.WriteInt(0); //?
            p.WriteInt(runSpd); //fly run
            p.WriteInt(walkSpd); //fly walk ?
            p.WriteDouble(1); //run speed multiplier
            p.WriteDouble(1); //atk speed multiplier

            p.WriteDouble(_player.Radius);
            p.WriteDouble(_player.Height);

            p.WriteInt(_player.HairStyle);
            p.WriteInt(_player.HairColor);
            p.WriteInt(_player.Face);
            p.WriteInt(_player.Builder);

            p.WriteString(_player.Title);

            p.WriteInt(_player.ClanId);
            p.WriteInt(_player.ClanCrestId);
            p.WriteInt(_player.AllianceId);
            p.WriteInt(_player.AllianceCrestId);

            p.WriteInt(_player.Sstt); //_relation
            p.WriteInt(_player.MountType);
            p.WriteInt(_player.GetPrivateStoreType()); //
            p.WriteInt(_player.PCreateItem > 0 ? 1 : 0);
            p.WriteInt(_player.PkKills);
            p.WriteInt(_player.PvpKills);

            p.WriteShort(_player.Cubics.Count);
            foreach (Cubic cub in _player.Cubics)
            {
                p.WriteShort(cub.Template.Id);
            }

            p.WriteInt(0); //1-isInPartyMatchRoom

            p.WriteInt(_player.AbnormalBitMask);

            //byte flymode = 0;

            //if (player.TransformID > 0)
            //    flymode = player.Transform.Template.MoveMode;

            p.WriteInt(0x00);

            p.WriteInt(_player.ClanPrivs);

            p.WriteShort(_player.RecHave); //c2  recommendations remaining
            p.WriteShort(_player.RecLeft); //c2  recommendations received
            p.WriteInt(_player.MountType > 0 ? _player.MountedTemplate.NpcId + 1000000 : 0); //moun t npcid
            p.WriteShort(_player.ItemLimitInventory);

            p.WriteInt((int)_player.ActiveClass.ClassId.Id);
            p.WriteInt(0); // special effects? circles around player...
            p.WriteInt(_player.CurCp); //max cp
            p.WriteInt(_player.CurCp);
            p.WriteInt(_player.GetEnchantValue());
            p.WriteInt(_player.TeamId);
            p.WriteInt(_player.GetClanCrestLargeId());
            p.WriteInt(_player.Noblesse);

            byte hero = _player.Heroic;
            p.WriteInt(hero);

            p.WriteInt(_player.IsFishing() ? 0x01 : 0x00); //Fishing Mode
            p.WriteInt(_player.GetFishx()); //fishing x
            p.WriteInt(_player.GetFishy()); //fishing y
            p.WriteInt(_player.GetFishz()); //fishing z
            p.WriteInt(_player.GetNameColor());

            p.WriteInt(_player.IsRunning);

            p.WriteInt(_player.ClanRank());
            p.WriteInt(_player.ClanType);

            p.WriteInt(_player.GetTitleColor());
            p.WriteInt(_player.CursedWeaponLevel);
        }
    }
}