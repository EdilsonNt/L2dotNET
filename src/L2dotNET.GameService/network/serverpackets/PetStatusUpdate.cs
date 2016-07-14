using L2dotNET.GameService.Model.Playable;
using L2dotNET.GameService.Model.Skills2;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class PetStatusUpdate
    {
        private readonly L2Summon _pet;

        public PetStatusUpdate(L2Summon pet)
        {
            _pet = pet;
        }

        internal static Packet ToPacket()
        {
            p.WriteInt(0xb6);
            p.WriteInt(_pet.ObjectSummonType);
            p.WriteInt(_pet.ObjId);
            p.WriteInt(_pet.X);
            p.WriteInt(_pet.Y);
            p.WriteInt(_pet.Z);
            p.WriteString("");
            p.WriteInt(_pet.CurrentTime);
            p.WriteInt(_pet.MaxTime);
            p.WriteInt(_pet.CurHp);
            p.WriteInt(_pet.CharacterStat.GetStat(EffectType.BMaxHp));
            p.WriteInt(_pet.CurMp);
            p.WriteInt(_pet.CharacterStat.GetStat(EffectType.BMaxMp));
            p.WriteInt(_pet.Level);
            p.WriteInt(_pet.StatusExp);
            p.WriteInt(_pet.GetExpCurrentLevel());
            p.WriteInt(_pet.GetExpToLevelUp());
        }
    }
}