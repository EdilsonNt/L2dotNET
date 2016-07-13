﻿using System.Linq;
using L2dotNET.GameService.Managers;
using L2dotNET.GameService.Model.Player;
using L2dotNET.GameService.Model.Player.Basic;
using L2dotNET.GameService.Network.Serverpackets;
using L2dotNET.GameService.World;

namespace L2dotNET.GameService.Network.Clientpackets
{
    class Say2 : GameServerNetworkRequest
    {
        public Say2(GameClient client, byte[] data)
        {
            Makeme(client, data);
        }

        private string _text,
                       _target;
        private SayIDList _type;

        public override void Read()
        {
            _text = ReadS();
            int typeId = ReadD();

            if ((typeId < 0) || (typeId >= SayId.MaxId))
            {
                typeId = 0;
            }

            _type = SayId.getType((byte)typeId);

            if (_type == SayIDList.CHAT_TELL)
            {
                _target = ReadS();
            }
        }

        public override void Run()
        {
            L2Player player = GetClient().CurrentPlayer;

            //if (_text.Contains("	Type=1 	ID=") && _text.Contains("	Color=0 	Underline=0 	Title="))
            //{
            //    string tx = _text.Replace("	Type=1 	ID=", "\f");
            //    tx = tx.Split('\f')[1].Split(' ')[0];
            //    int id = int.Parse(tx);
            //    L2Item item = player.getItemByObjId(id);
            //    if (item == null)
            //    {
            //        player.sendMessage("You cant publish this item.");
            //        player.sendActionFailed();
            //        return;
            //    }
            //    else
            //        RqItemManager.getInstance().postItem(item);
            //}

            CreatureSay cs = new CreatureSay(player.ObjId, _type, player.Name, _text);

            switch (_type)
            {
                case SayIDList.CHAT_NORMAL:
                {
                    char[] arr = _text.ToCharArray();
                    if (arr[0] == '.')
                    {
                        if (PointCmdManager.GetInstance().Pointed(player, _text))
                        {
                            return;
                        }
                    }

                    foreach (L2Player o in player.KnownObjects.Values.OfType<L2Player>().Where(o => player.IsInsideRadius(o, 1250, true, false)))
                    {
                        o.SendPacket(cs);
                    }

                    player.SendPacket(cs);
                }

                    break;
                case SayIDList.CHAT_SHOUT:
                    //L2World.Instance.BroadcastToRegion(player.X, player.Y, cs);
                    break;
                case SayIDList.CHAT_TELL:
                {
                    L2Player target;
                    if (player.Name.Equals(_target))
                    {
                        target = player;
                    }
                    //else
                    //    target = L2World.Instance.GetPlayer(_target);

                    //if (target == null)
                    //{
                    //    SystemMessage sm = new SystemMessage(SystemMessage.SystemMessageId.S1_IS_NOT_ONLINE);
                    //    sm.AddString(_target);
                    //    player.sendPacket(sm);

                    //    player.sendActionFailed();
                    //    return;
                    //}
                    //else
                    //{
                    //    if (target.WhieperBlock)
                    //    {
                    //        player.sendSystemMessage(SystemMessage.SystemMessageId.THE_PERSON_IS_IN_MESSAGE_REFUSAL_MODE);
                    //        player.sendActionFailed();
                    //        return;
                    //    }
                    //    else
                    //    {
                    //        player.sendPacket(new CreatureSay(player.ObjID, Type, "->" + target.Name, _text));
                    //        target.sendPacket(cs);
                    //    }
                    //}
                }
                    break;
                case SayIDList.CHAT_PARTY:
                    player.Party?.BroadcastToMembers(cs);
                    break;
                case SayIDList.CHAT_MARKET:
                    foreach (L2Player p in L2World.Instance.GetPlayers())
                    {
                        p.SendPacket(cs);
                    }

                    break;
                case SayIDList.CHAT_HERO:
                {
                    if (player.Heroic == 1)
                    {
                        foreach (L2Player p in L2World.Instance.GetPlayers())
                        {
                            p.SendPacket(cs);
                        }
                    }
                    else
                    {
                        player.SendActionFailed();
                    }
                }

                    break;
            }
        }
    }
}