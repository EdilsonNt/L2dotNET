namespace L2dotNET.GameService.Network.Serverpackets
{
    class NpcInfoMonrace
    {
        //private MonsterRunner runner;
        //public NpcInfoMonrace(MonsterRunner runner)
        //{
        //    this.runner = runner;
        //}

        internal static Packet ToPacket()
        {
            p.WriteInt(0x0c);
            //p.WriteInt(runner.id);
            //p.WriteInt(runner.npcId + 1000000);
            //p.WriteInt(0);
            //p.WriteInt(runner.x);
            //p.WriteInt(runner.y);
            //p.WriteInt(runner.z);
            //p.WriteInt(runner.heading);
            //p.WriteInt(0);
            //p.WriteInt(0);
            //p.WriteInt(0);
            //p.WriteInt(runner.cur_speed);
            //p.WriteInt(0);
            //p.WriteInt(0);  // swimspeed
            //p.WriteInt(0);  // swimspeed
            //p.WriteInt(runner.cur_speed);
            //p.WriteInt(0);
            //p.WriteInt(runner.cur_speed);
            //p.WriteInt(0);
            //p.WriteDouble(runner.cur_speed * 1f / 130);
            //p.WriteDouble(1.0);
            //p.WriteDouble(runner.npcTemplate.CollisionRadius);
            //p.WriteDouble(runner.npcTemplate.CollisionHeight);
            //p.WriteInt(0); // right hand weapon
            //p.WriteInt(0);
            //p.WriteInt(0); // left hand weapon
            //p.WriteInt(1);	// name above char 1=true ... ??
            //p.WriteInt(1);
            //p.WriteInt(0);
            //p.WriteInt(0);
            //p.WriteInt(0); // invisible ?? 0=false  1=true   2=summoned (only works if model has a summon animation)
            //p.WriteString("");//name
            //p.WriteString("");//title
            //p.WriteInt(0x00); // Title color 0=client default
            //p.WriteInt(0x00); //pvp flag
            //p.WriteInt(0x00); // karma

            //p.WriteInt(0);  // C2
            //p.WriteInt(0); //clan id
            //p.WriteInt(0); //crest id
            //p.WriteInt(0); // ally id
            //p.WriteInt(0); // all crest
            //p.WriteInt(0); // C2

            //p.WriteInt(0);
            //p.WriteDouble(runner.npcTemplate.CollisionRadius);
            //p.WriteDouble(runner.npcTemplate.CollisionHeight);
            //p.WriteInt(0); // enchant
            //p.WriteInt(0); // C6
            //p.WriteInt(0);
            //p.WriteInt(0);  //red?
            //p.WriteInt(0x01);
            //p.WriteInt(0x01);
            //p.WriteInt(0);
            //p.WriteInt(0);//freya
        }
    }
}