using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PartySmallWindowAll
    {
        private const byte Opcode = 0x4e;

        internal static Packet ToPacket(L2Player player, L2Party party)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(party.Leader.ObjId);
            p.WriteInt(party.ItemDistribution);
            p.WriteInt(party.Members.Count - 1);

            foreach (L2Player member in party.Members)
            {
                if(member == player)
                    continue;

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
                p.WriteInt(0x00); // p.WriteInt(0x01); ??
                p.WriteInt((int)member.BaseClass.ClassId.ClassRace);
            }
            return p;
        }
    }
}