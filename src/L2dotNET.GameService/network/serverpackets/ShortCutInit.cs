using System.Collections.Generic;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Player.General;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ShortCutInit
    {
        private const byte Opcode = 0x45;

        internal static Packet ToPacket(L2Player player)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(player.Shortcuts.Count);

            foreach (L2Shortcut sc in player.Shortcuts)
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
            return p;
        }
    }
}