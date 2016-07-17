using L2dotNET.GameService.Model.Player.General;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ShortCutRegister
    {
        private const byte Opcode = 0x44;

        internal static Packet ToPacket(L2Shortcut cut)
        {
            Packet p = new Packet(Opcode);

            p.WriteInt(cut.Type);
            p.WriteInt(cut.Slot + (cut.Page * 12));

            switch (cut.Type)
            {
                case L2Shortcut.TypeItem:
                    p.WriteInt(cut.Id);
                    p.WriteInt(cut.CharacterType);
                    p.WriteInt(-1); //getSharedReuseGroup
                    break;
                case L2Shortcut.TypeSkill:
                    p.WriteInt(cut.Id);
                    p.WriteInt(cut.Level);
                    p.WriteInt(0x00); // C5
                    p.WriteInt(cut.CharacterType);
                    break;
                default:
                    p.WriteInt(cut.Id);
                    p.WriteInt(cut.CharacterType);
                    break;
            }
            return p;
        }
    }
}