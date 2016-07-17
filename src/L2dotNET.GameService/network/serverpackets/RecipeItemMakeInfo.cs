using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Skills2;
using L2dotNET.GameService.Tables;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class RecipeItemMakeInfo
    {
        private const byte Opcode = 0xD7;

        internal static Packet ToPacket(L2Player player, L2Recipe rec, int result)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(rec.RecipeId);
            p.WriteInt(rec.Iscommonrecipe);
            p.WriteInt((int)player.CurMp);
            p.WriteInt((int)player.CharacterStat.GetStat(EffectType.BMaxMp));
            p.WriteInt(result);
            return p;
        }
    }
}