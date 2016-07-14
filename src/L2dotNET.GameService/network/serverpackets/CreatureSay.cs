using L2dotNET.GameService.Model.Player.Basic;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class CreatureSay
    {
        private readonly int _objectId;
        private readonly SayIDList _type;
        private readonly string _charName;
        public string Text { get; set; }

        public CreatureSay(int id, SayIDList type, string name, string text)
        {
            _objectId = id;
            _type = type;
            _charName = name;
            Text = text;
        }

        public CreatureSay(SayIDList type, string text = "")
        {
            _type = type;
            Text = text;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0x4a);
            p.WriteInt(_objectId);
            p.WriteInt((byte)_type);
            p.WriteString(_charName);
            p.WriteString(Text);
        }
    }
}