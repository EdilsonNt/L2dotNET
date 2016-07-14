using L2dotNET.GameService.Model.Player.General;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class ShortCutRegister
    {
        private readonly L2Shortcut _cut;

        public ShortCutRegister(L2Shortcut cut)
        {
            _cut = cut;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x44);

            p.WriteInt(_cut.Type);
            p.WriteInt(_cut.Slot + (_cut.Page * 12));

            switch (_cut.Type)
            {
                case L2Shortcut.TypeItem:
                    p.WriteInt(_cut.Id);
                    p.WriteInt(_cut.CharacterType);
                    p.WriteInt(-1); //getSharedReuseGroup
                    break;
                case L2Shortcut.TypeSkill:
                    p.WriteInt(_cut.Id);
                    p.WriteInt(_cut.Level);
                    p.WriteInt(0x00); // C5
                    p.WriteInt(_cut.CharacterType);
                    break;
                default:
                    p.WriteInt(_cut.Id);
                    p.WriteInt(_cut.CharacterType);
                    break;
            }
        }
    }
}