using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PartySmallWindowUpdate
    {
        private const byte Opcode = 0x52;
        internal static Packet ToPacket(L2Player member)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(member.ObjId);
            p.WriteString(member.Name);
            p.WriteInt((int)member.CurCp);
            p.WriteInt(member.MaxCp);
            p.WriteInt((int)member.CurHp);
            p.WriteInt(member.MaxHp);
            p.WriteInt((int)member.CurMp);
            p.WriteInt(member.MaxMp);
            p.WriteInt(member.Level);
            p.WriteInt((int)member.ActiveClass.ClassId.Id);
            return p;
        }
    }
}