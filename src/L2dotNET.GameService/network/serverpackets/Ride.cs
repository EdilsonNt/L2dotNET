using L2dotNET.GameService.Model.Player;
using L2dotNET.Network;

namespace L2dotNET.GameService.Network.Serverpackets
{
    class Ride
    {
        private const byte Opcode = 0x86;
        private static int _id;
        private static int _bRide;
        private static int _rideType;
        private static int _npcId;

        internal static Packet ToPacket(L2Player player, bool mount, int npc = 0)
        {
            _id = player.ObjId;
            _bRide = mount ? 1 : 0;
            _npcId = npc + 1000000;
            switch (_npcId)
            {
                case 12526:
                case 12527: // Striders
                case 12528:
                    _rideType = 1;
                    break;

                case 12621: // Wyvern
                    _rideType = 2;
                    break;
            }
            Packet p = new Packet(Opcode);
            p.WriteInt(_id);
            p.WriteInt(_bRide);
            p.WriteInt(_rideType);
            p.WriteInt(_npcId);
            return p;
        }
    }
}