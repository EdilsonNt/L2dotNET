﻿using System.Collections.Generic;
using L2dotNET.GameService.Model.Npcs;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.World;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class Die
    {
        private readonly int _sId;
        private int _mNVillage;
        private int _mNAgit;
        private const int MNBattleCamp = 0;
        private int _mNCastle;
        private readonly int _mSpoil;
        private int _mNOriginal;
        private int _mNFotress;
        private const int MNAgathion = 0;
        private const bool MBShow = false;

        private List<int> _items;

        public void AddItem(int id)
        {
            if (_items == null)
            {
                _items = new List<int>();
            }

            _items.Add(id);
        }

        public Die(L2Character cha)
        {
            _sId = cha.ObjId;

            if (cha is L2Player)
            {
                DiePlayer((L2Player)cha);
            }
            else if (cha is L2Warrior)
            {
                _mSpoil = ((L2Warrior)cha).SpoilActive ? 1 : 0;
            }
        }

        private void DiePlayer(L2Player player)
        {
            _mNVillage = 1;
            _mNOriginal = player.Builder;

            if (player.ClanId > 0)
            {
                _mNAgit = player.Clan.HideoutId > 0 ? 1 : 0;
                _mNCastle = player.Clan.CastleId > 0 ? 1 : 0;
                _mNFotress = player.Clan.FortressId > 0 ? 1 : 0;
            }

            AddItem(57);
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x06);
            p.WriteInt(_sId);
            p.WriteInt(_mNVillage); //0
            p.WriteInt(_mNAgit); //1
            p.WriteInt(_mNCastle); //2
            p.WriteInt(MNBattleCamp); //4
            p.WriteInt(_mSpoil);
            p.WriteInt(_mNOriginal); //5
            p.WriteInt(_mNFotress); //3

            p.WriteInt(0);
            //p.WriteInt(m_bShow ? 1 : 0);
            p.WriteInt(MNAgathion); //21
            p.WriteInt(_items?.Count ?? 0); //22+

            if (_items == null)
            {
                return;
            }

            foreach (int id in _items)
            {
                p.WriteInt(id);
            }
        }
    }
}