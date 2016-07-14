using L2dotNET.GameService.Model.Npcs.Ai;
using L2dotNET.GameService.Model.Structures;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class AgitDecoInfo
    {
        private readonly Hideout _hideout;

        public AgitDecoInfo(Hideout hideout)
        {
            _hideout = hideout;
        }

        internal static Packet ToPacket()
        {
            Packet p = new Packet(Opcode);
            p.WriteInt(0xf7);
            p.WriteInt(_hideout.ID); // clanhall id
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypeHpregen)); // FUNC_RESTORE_HP (Fireplace)
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypeMpregen)); // FUNC_RESTORE_MP (Carpet)
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypeCpregen)); // FUNC_RESTORE_MP (Statue)
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypeXprestore)); // FUNC_RESTORE_EXP (Chandelier)
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypeTeleport)); // FUNC_TELEPORT (Mirror)
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypeBroadcast)); // Crytal
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypeCurtain)); // Curtain
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypeHanging)); // FUNC_ITEM_CREATE (Magic Curtain)
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypeBuff)); // FUNC_SUPPORT
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypeOuterflag)); // FUNC_SUPPORT (Flag)
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypePlatform)); // Front Platform
            p.WriteInt(_hideout.GetFuncLevel(AgitManagerAi.DecotypeItem)); // FUNC_ITEM_CREATE
            p.WriteInt(0);
            p.WriteInt(0);
        }
    }
}