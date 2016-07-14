using System.Collections.Generic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Player.General;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ShortCutInit
    {
        private readonly List<L2Shortcut> _shortcuts;

        public ShortCutInit(L2Player player)
        {
            _shortcuts = player.Shortcuts;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x45);
            p.WriteInt(_shortcuts.Count);

            foreach (L2Shortcut sc in _shortcuts)
            {
                p.WriteInt(sc.Type);
                p.WriteInt(sc.Slot + (sc.Page * 12));

                switch (sc.Type)
                {
                    case L2Shortcut.TypeItem:
                        p.WriteInt(sc.Id);
                        p.WriteInt(0x01);
                        p.WriteInt(-1); //getSharedReuseGroup
                        p.WriteInt(0x00);
                        p.WriteInt(0x00);
                        p.WriteInt(0x00);
                        break;
                    case L2Shortcut.TypeSkill:
                        p.WriteInt(sc.Id);
                        p.WriteInt(sc.Level);
                        p.WriteInt(0x00); // C5
                        p.WriteInt(0x01); // C6
                        break;
                    default:
                        p.WriteInt(sc.Id);
                        p.WriteInt(0x01); // C6
                        break;
                }
            }
        }
    }
}