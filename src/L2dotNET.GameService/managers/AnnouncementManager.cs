using System.Collections.Generic;
using System.Linq;
using log4net;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Player.Basic;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.GameService.World;
using L2dotNET.Models;
using L2dotNET.Services.Contracts;
using Ninject;

namespace L2dotNET.GameService.Managers
{
    class AnnouncementManager
    {
        [Inject]
        public IServerService ServerService => GameServer.Kernel.Get<IServerService>();

        private static readonly ILog Log = LogManager.GetLogger(typeof(AnnouncementManager));

        private static volatile AnnouncementManager _instance;
        private static readonly object SyncRoot = new object();

        public List<AnnouncementModel> Announcements { get; set; }

        public static AnnouncementManager Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                lock (SyncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new AnnouncementManager();
                    }
                }

                return _instance;
            }
        }

        public void Initialize()
        {
            Announcements = ServerService.GetAnnouncementsList();
            Log.Info($"Announcement manager: Loaded {Announcements.Count} annoucements.");
        }

        public void Announce(string text)
        {
            foreach (L2Player p in L2World.Instance.GetPlayers())
            {
                p.SendPacket(CreatureSay.ToPacket(SayIDList.CHAT_ANNOUNCE, text));
            }
        }

        public void CriticalAnnounce(string text)
        {
            foreach (L2Player p in L2World.Instance.GetPlayers())
            {
                p.SendPacket(CreatureSay.ToPacket(SayIDList.CHAT_CRITICAL_ANNOUNCE, text));
            }
        }

        public void ScreenAnnounce(string text)
        {
            foreach (L2Player p in L2World.Instance.GetPlayers())
            {
                p.SendPacket(CreatureSay.ToPacket(SayIDList.CHAT_SCREEN_ANNOUNCE, text));
            }
        }

        public void OnEnter(L2Player player)
        {
            if ((Announcements == null) || (Announcements.Count == 0))
            {
                return;
            }

            foreach (AnnouncementModel announcement in Announcements.Where(announcement => announcement.Type == 0))
            {
                player.SendPacket(CreatureSay.ToPacket(SayIDList.CHAT_ANNOUNCE, announcement.Text));
            }
        }
    }
}