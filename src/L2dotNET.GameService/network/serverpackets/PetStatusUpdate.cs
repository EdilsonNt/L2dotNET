using L2dotNET.GameService.Model.Playable;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PetStatusUpdate
    {
        private const byte Opcode = 0xb6;

        internal static Packet ToPacket(L2Summon pet)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(pet.ObjectSummonType);
            p.WriteInt(pet.ObjId);
            p.WriteInt(pet.X);
            p.WriteInt(pet.Y);
            p.WriteInt(pet.Z);
            p.WriteString(pet.Title);
            p.WriteInt(pet.CurrentTime);
            p.WriteInt(pet.MaxTime);
            p.WriteInt((int)pet.CurHp);
            p.WriteInt((int)pet.CharacterStat.GetStat(EffectType.BMaxHp));
            p.WriteInt((int)pet.CurMp);
            p.WriteInt((int)pet.CharacterStat.GetStat(EffectType.BMaxMp));
            p.WriteInt(pet.Level);
            p.WriteLong(pet.StatusExp);
            p.WriteLong(pet.GetExpCurrentLevel());
            p.WriteLong(pet.GetExpToLevelUp());
            return p;
        }
    }
}