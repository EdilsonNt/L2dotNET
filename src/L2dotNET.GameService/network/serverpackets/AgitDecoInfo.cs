using L2dotNET.GameService.Model.Npcs.Ai;
using L2dotNET.GameService.Model.Structures;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class AgitDecoInfo
    {
        private const byte Opcode = 0xf7;

        internal static Packet ToPacket(Hideout hideout)
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(hideout.ID); // clanhall id
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypeHpregen)); // FUNC_RESTORE_HP (Fireplace)
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypeMpregen)); // FUNC_RESTORE_MP (Carpet)
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypeCpregen)); // FUNC_RESTORE_MP (Statue)
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypeXprestore)); // FUNC_RESTORE_EXP (Chandelier)
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypeTeleport)); // FUNC_TELEPORT (Mirror)
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypeBroadcast)); // Crytal
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypeCurtain)); // Curtain
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypeHanging)); // FUNC_ITEM_CREATE (Magic Curtain)
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypeBuff)); // FUNC_SUPPORT
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypeOuterflag)); // FUNC_SUPPORT (Flag)
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypePlatform)); // Front Platform
            p.WriteInt(hideout.GetFuncLevel(AgitManagerAi.DecotypeItem)); // FUNC_ITEM_CREATE
            p.WriteInt(0);
            p.WriteInt(0);
            return p;
        }
    }
}