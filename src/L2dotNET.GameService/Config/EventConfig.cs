﻿using System.ComponentModel;
using Newtonsoft.Json;

namespace L2dotNET.GameService.Config
{
    ///<summary>Event Config.</summary>
    public class EventConfig
    {
        ///<summary>Olympiad Config.</summary>
        [JsonProperty(PropertyName = "Olympiad", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public Olympiad Olympiad { get; set; }

        ///<summary>Seven Signs Config.</summary>
        [JsonProperty(PropertyName = "SevenSigns", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public SevenSigns SevenSigns { get; set; }

        ///<summary>Four Sepulchers Config.</summary>
        [JsonProperty(PropertyName = "FourSepulchers", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public FourSepulchers FourSepulchers { get; set; }

        ///<summary>Dimension Rift Config.</summary>
        [JsonProperty(PropertyName = "DimensionRift", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public DimensionRift DimensionRift { get; set; }

        ///<summary>Wedding Config.</summary>
        [JsonProperty(PropertyName = "Wedding", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public Wedding Wedding { get; set; }

        ///<summary>Lottery Config.</summary>
        [JsonProperty(PropertyName = "Lottery", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public Lottery Lottery { get; set; }

        ///<summary>Fishing Config.</summary>
        [JsonProperty(PropertyName = "Fishing", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public Fishing Fishing { get; set; }
    }

    ///<summary>Olympiad Config.</summary>
    public class Olympiad
    {
        ///<summary>Olympiad start time hour, default 18 (6PM).</summary>
        [DefaultValue(18)]
        [JsonProperty(PropertyName = "StartTime", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int StartTime { get; set; }

        ///<summary>Olympiad start time minutes, default 00.</summary>
        [DefaultValue(0)]
        [JsonProperty(PropertyName = "Min", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Min { get; set; }

        ///<summary>Olympiad competition period, default 6 hours (should be changed by steps of 10mins).</summary>
        [DefaultValue(21600000)]
        [JsonProperty(PropertyName = "CPeriod", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int CPeriod { get; set; }

        ///<summary>Olympiad battle period, default 6 minutes.</summary>
        [DefaultValue(180000)]
        [JsonProperty(PropertyName = "Battle", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Battle { get; set; }

        ///<summary>Olympiad weekly period, default 1 week.</summary>
        [DefaultValue(604800000)]
        [JsonProperty(PropertyName = "WPeriod", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int WPeriod { get; set; }

        ///<summary>Olympiad validation period, default 24 hours.</summary>
        [DefaultValue(86400000)]
        [JsonProperty(PropertyName = "VPeriod", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int VPeriod { get; set; }

        ///<summary>Time to wait before teleported to arena, default: 30 seconds.</summary>
        [DefaultValue(30)]
        [JsonProperty(PropertyName = "WaitTime", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int WaitTime { get; set; }

        ///<summary>Time to wait before battle starts (at 20s characters receive buffs), default: 60 seconds.</summary>
        [DefaultValue(60)]
        [JsonProperty(PropertyName = "WaitBattle", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int WaitBattle { get; set; }

        ///<summary>Time to wait before teleported back to town, default: 40 seconds.</summary>
        [DefaultValue(40)]
        [JsonProperty(PropertyName = "WaitEnd", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int WaitEnd { get; set; }

        ///<summary>Rewarded points for the first mpiad cycle, default: 18.</summary>
        [DefaultValue(18)]
        [JsonProperty(PropertyName = "StartPoints", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int StartPoints { get; set; }

        ///<summary>Points allowed every week after first cycle, default: 3.</summary>
        [DefaultValue(3)]
        [JsonProperty(PropertyName = "WeeklyPoints", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int WeeklyPoints { get; set; }

        ///<summary>Required number of matches in order to be classed as hero, default: 9.</summary>
        [DefaultValue(5)]
        [JsonProperty(PropertyName = "MinMatchesToBeClassed", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int MinMatchesToBeClassed { get; set; }

        ///<summary>Required number of participants for the class based games, default: 5.</summary>
        [DefaultValue(5)]
        [JsonProperty(PropertyName = "ClassedParticipants", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ClassedParticipants { get; set; }

        ///<summary>Required number of participants for the non-class based games, default: 9.</summary>
        [DefaultValue(9)]
        [JsonProperty(PropertyName = "NonClassedParticipants", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int NonClassedParticipants { get; set; }

        ///<summary>Reward for the class based games.</summary>
        ///<summary>Format: itemId1,itemNum1;itemId2,itemNum2.</summary>
        ///<summary>Default: 6651,50.</summary>
        [JsonProperty(PropertyName = "ClassedReward", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public ItemAmount[] ClassedReward { get; set; } = /*DefaultValue*/ { new ItemAmount
                                                                             {
                                                                                 ItemId = 6651,
                                                                                 Amount = 50
                                                                             } };

        ///<summary>Reward for the non-class based games.</summary>
        ///<summary>Format: itemId1,itemNum1;itemId2,itemNum2.</summary>
        ///<summary>Default: 6651,30.</summary>
        [JsonProperty(PropertyName = "NonClassedReward", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public ItemAmount[] NonClassedReward { get; set; } = /*DefaultValue*/ { new ItemAmount
                                                                                {
                                                                                    ItemId = 6651,
                                                                                    Amount = 30
                                                                                } };

        ///<summary>Rate to exchange points to reward item, default: 1000.</summary>
        [DefaultValue(1000)]
        [JsonProperty(PropertyName = "GPPerPoint", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int GpPerPoint { get; set; }

        ///<summary>CRPs for heroes in clan, default: 300.</summary>
        [DefaultValue(300)]
        [JsonProperty(PropertyName = "HeroPoints", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int HeroPoints { get; set; }

        ///<summary>Noblesse points awarded to Rank 1 members, default: 100.</summary>
        [DefaultValue(100)]
        [JsonProperty(PropertyName = "Rank1Points", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Rank1Points { get; set; }

        ///<summary>Noblesse points awarded to Rank 2 members, default: 75.</summary>
        [DefaultValue(75)]
        [JsonProperty(PropertyName = "Rank2Points", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Rank2Points { get; set; }

        ///<summary>Noblesse points awarded to Rank 3 members, default: 55.</summary>
        [DefaultValue(55)]
        [JsonProperty(PropertyName = "Rank3Points", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Rank3Points { get; set; }

        ///<summary>Noblesse points awarded to Rank 4 members, default: 40.</summary>
        [DefaultValue(40)]
        [JsonProperty(PropertyName = "Rank4Points", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Rank4Points { get; set; }

        ///<summary>Noblesse points awarded to Rank 5 members, default: 30.</summary>
        [DefaultValue(30)]
        [JsonProperty(PropertyName = "Rank5Points", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Rank5Points { get; set; }

        ///<summary>Maximum points that player can gain/lose on a match, default: 10.</summary>
        [DefaultValue(10)]
        [JsonProperty(PropertyName = "MaxPoints", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int MaxPoints { get; set; }

        ///<summary>Olympiad Managers announce each start of fight, default: True.</summary>
        [DefaultValue(true)]
        [JsonProperty(PropertyName = "AnnounceGames", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool AnnounceGames { get; set; }

        ///<summary>Divider for points in classed and non-classed games, default: 3, 5.</summary>
        [DefaultValue(3)]
        [JsonProperty(PropertyName = "DividerClassed", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int DividerClassed { get; set; }

        ///<summary>Divider for points in classed and non-classed games, default: 3, 5.</summary>
        [DefaultValue(3)]
        [JsonProperty(PropertyName = "DividerNonClassed", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int DividerNonClassed { get; set; }
    }

    ///<summary>Seven Signs Config.</summary>
    public class SevenSigns
    {
        ///<summary>Dawn:.</summary>
        ///<summary>True - Players not owning castle need pay participation fee.</summary>
        ///<summary>False - Anyone can join Dawn.</summary>
        [DefaultValue(true)]
        [JsonProperty(PropertyName = "CastleForDawn", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool CastleForDawn { get; set; }

        ///<summary>Dusk:.</summary>
        ///<summary>True - Players owning castle can not join Dusk side.</summary>
        ///<summary>False - Anyone can join Dusk.</summary>
        [DefaultValue(true)]
        [JsonProperty(PropertyName = "CastleForDusk", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool CastleForDusk { get; set; }

        ///<summary>Save SevenSigns status only each 30 mins and after period change.</summary>
        ///<summary>Player info saved only during periodic data store (set by CharacterDataStoreInterval) and logout.</summary>
        ///<summary>If False then save info and status immediately after every changes (heavy but accurate).</summary>
        ///<summary>Default: True.</summary>
        [DefaultValue(true)]
        [JsonProperty(PropertyName = "LazyUpdate", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool LazyUpdate { get; set; }

        ///<summary>Festival.</summary>
        public Festival Festival { get; set; }
    }

    ///<summary>Festival Config.</summary>
    public class Festival
    {
        ///<summary>Minimum Players for participate in SevenSigns Festival.</summary>
        ///<summary>Default: 5.</summary>
        [DefaultValue(5)]
        [JsonProperty(PropertyName = "MinPlayer", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int MinPlayer { get; set; }

        ///<summary>Maximum contribution per player during festival.</summary>
        ///<summary>/!\ This value is NOT impacted by server drop rate.</summary>
        [DefaultValue(1000000)]
        [JsonProperty(PropertyName = "MaxPlayerContrib", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int MaxPlayerContrib { get; set; }

        ///<summary>Festival Manager Start time.</summary>
        ///<summary>Default: 2 minutes.</summary>
        [DefaultValue(120000)]
        [JsonProperty(PropertyName = "ManagerStart", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ManagerStart { get; set; }

        ///<summary>Festival Length.</summary>
        ///<summary>Default: 18 minutes.</summary>
        [DefaultValue(1080000)]
        [JsonProperty(PropertyName = "Length", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Length { get; set; }

        ///<summary>Festival Cycle Length.</summary>
        ///<summary>Default: 38 Minutes (20 minutes wait time, + Festival time).</summary>
        [DefaultValue(2280000)]
        [JsonProperty(PropertyName = "CycleLength", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int CycleLength { get; set; }

        ///<summary>At what point the first festival spawn occures.</summary>
        ///<summary>Default: 2 minutes.</summary>
        [DefaultValue(120000)]
        [JsonProperty(PropertyName = "FirstSpawn", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int FirstSpawn { get; set; }

        ///<summary>At what Point the first festival swarm occures.</summary>
        ///<summary>Default: 5 minutes.</summary>
        [DefaultValue(300000)]
        [JsonProperty(PropertyName = "FirstSwarm", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int FirstSwarm { get; set; }

        ///<summary>At what Point the Second Festival spawn occures.</summary>
        ///<summary>Default: 9 minutes.</summary>
        [DefaultValue(540000)]
        [JsonProperty(PropertyName = "SecondSpawn", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int SecondSpawn { get; set; }

        ///<summary>At what Point the Second Festival Swarm occures.</summary>
        ///<summary>Default: 12 minutes.</summary>
        [DefaultValue(720000)]
        [JsonProperty(PropertyName = "SecondSwarm", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int SecondSwarm { get; set; }

        ///<summary>At what point the Chests Spawn in.</summary>
        ///<summary>Default: 15 minutes.</summary>
        [DefaultValue(900000)]
        [JsonProperty(PropertyName = "ChestSpawn", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int ChestSpawn { get; set; }
    }

    ///<summary>Four Sepulchers Config.</summary>
    public class FourSepulchers
    {
        ///<summary>Default: 50.</summary>
        [DefaultValue(50)]
        [JsonProperty(PropertyName = "TimeOfAttack", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int TimeOfAttack { get; set; }

        ///<summary>Default: 3.</summary>
        [DefaultValue(3)]
        [JsonProperty(PropertyName = "TimeOfEntry", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int TimeOfEntry { get; set; }

        ///<summary>Default: 2.</summary>
        [DefaultValue(2)]
        [JsonProperty(PropertyName = "TimeOfWarmUp", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int TimeOfWarmUp { get; set; }

        ///<summary>Default: 4.</summary>
        [DefaultValue(4)]
        [JsonProperty(PropertyName = "NumberOfNecessaryPartyMembers", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int NumberOfNecessaryPartyMembers { get; set; }
    }

    ///<summary>Dimension Rift Config.</summary>
    public class DimensionRift
    {
        ///<summary>Minimal party size to enter rift. Min = 2, Max = 9 (retail = 2).</summary>
        ///<summary>If in rift party will become smaller all members will be teleported back.</summary>
        [DefaultValue(2)]
        [JsonProperty(PropertyName = "RiftMinPartySize", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int RiftMinPartySize { get; set; }

        ///<summary>Number of maximum jumps between rooms allowed, after this time party will be teleported back.</summary>
        [DefaultValue(4)]
        [JsonProperty(PropertyName = "MaxRiftJumps", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int MaxRiftJumps { get; set; }

        ///<summary>Time in ms the party has to wait until the mobs spawn when entering a room. C4 retail: 10s.</summary>
        [DefaultValue(10000)]
        [JsonProperty(PropertyName = "RiftSpawnDelay", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int RiftSpawnDelay { get; set; }

        ///<summary>Time between automatic jumps in seconds (retail: 8min(480sec) - 10min(600sec)).</summary>
        [DefaultValue(480)]
        [JsonProperty(PropertyName = "AutoJumpsDelayMin", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int AutoJumpsDelayMin { get; set; }

        ///<summary>Time between automatic jumps in seconds (retail: 8min(480sec) - 10min(600sec)).</summary>
        [DefaultValue(600)]
        [JsonProperty(PropertyName = "AutoJumpsDelayMax", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int AutoJumpsDelayMax { get; set; }

        ///<summary>Time Multiplier for stay in the boss room.</summary>aaaaaaaaaa
        [DefaultValue(1.0)]
        [JsonProperty(PropertyName = "BossRoomTimeMultiply", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public double BossRoomTimeMultiply { get; set; }

        ///<summary>Cost in dimension fragments to enter the rift, each party member must own this amount.</summary>
        [DefaultValue(18)]
        [JsonProperty(PropertyName = "RecruitCost", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int RecruitCost { get; set; }

        ///<summary>Cost in dimension fragments to enter the rift, each party member must own this amount.</summary>
        [DefaultValue(21)]
        [JsonProperty(PropertyName = "SoldierCost", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int SoldierCost { get; set; }

        ///<summary>Cost in dimension fragments to enter the rift, each party member must own this amount.</summary>
        [DefaultValue(24)]
        [JsonProperty(PropertyName = "OfficerCost", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int OfficerCost { get; set; }

        ///<summary>Cost in dimension fragments to enter the rift, each party member must own this amount.</summary>
        [DefaultValue(27)]
        [JsonProperty(PropertyName = "CaptainCost", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int CaptainCost { get; set; }

        ///<summary>Cost in dimension fragments to enter the rift, each party member must own this amount.</summary>
        [DefaultValue(30)]
        [JsonProperty(PropertyName = "CommanderCost", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int CommanderCost { get; set; }

        ///<summary>Cost in dimension fragments to enter the rift, each party member must own this amount.</summary>
        [DefaultValue(33)]
        [JsonProperty(PropertyName = "HeroCost", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int HeroCost { get; set; }
    }

    ///<summary>Wedding Config.</summary>
    ///<summary>Wedding Manager: //spawn 50007.</summary>
    public class Wedding
    {
        ///<summary>True allows Wedding, False disables it.</summary>
        ///<summary>The Wedding Manager is disabled until this setting is put to True.</summary>
        [DefaultValue(true)]
        [JsonProperty(PropertyName = "AllowWedding", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool AllowWedding { get; set; }

        ///<summary>Cost of wedding, price in adenas.</summary>
        [DefaultValue(1000000)]
        [JsonProperty(PropertyName = "WeddingPrice", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int WeddingPrice { get; set; }

        ///<summary>Homosexual marriages allowed, False by default.</summary>
        [DefaultValue(false)]
        [JsonProperty(PropertyName = "WeddingAllowSameSex", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool WeddingAllowSameSex { get; set; }

        ///<summary>Do players require to wear formal wear ? True by default.</summary>
        [DefaultValue(true)]
        [JsonProperty(PropertyName = "WeddingFormalWear", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool WeddingFormalWear { get; set; }
    }

    ///<summary>Lottery Config.</summary>
    public class Lottery
    {
        ///<summary>Initial Lottery prize.</summary>
        [DefaultValue(50000)]
        [JsonProperty(PropertyName = "Prize", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int Prize { get; set; }

        ///<summary>Lottery Ticket Price.</summary>
        [DefaultValue(2000)]
        [JsonProperty(PropertyName = "TicketPrice", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public int TicketPrice { get; set; }

        ///<summary>What part of jackpot amount should receive characters who pick 5 winning numbers.</summary>
        [DefaultValue(0.6)]
        [JsonProperty(PropertyName = "Winning5NumberRate", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public double Winning5NumberRate { get; set; }

        ///<summary>What part of jackpot amount should receive characters who pick 4 winning numbers.</summary>
        [DefaultValue(0.2)]
        [JsonProperty(PropertyName = "Winning4NumberRate", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public double Winning4NumberRate { get; set; }

        ///<summary>What part of jackpot amount should receive characters who pick 3 winning numbers.</summary>
        [DefaultValue(0.2)]
        [JsonProperty(PropertyName = "Winning3NumberRate", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public double Winning3NumberRate { get; set; }

        ///<summary>How much adena receive characters who pick two or less of the winning number.</summary>
        [DefaultValue(200)]
        [JsonProperty(PropertyName = "Winning2And1NumberPrize", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public double Winning2And1NumberPrize { get; set; }
    }

    ///<summary>Fishing.</summary>
    public class Fishing
    {
        ///<summary>Enable or disable the Fishing Tournament system.</summary>
        [DefaultValue(true)]
        [JsonProperty(PropertyName = "FishChampionshipEnabled", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public bool FishChampionshipEnabled { get; set; }

        ///<summary>Item Id used as reward.Item count used as reward (for the 5 first winners) - 1.</summary>
        [DefaultValue(800000)]
        [JsonProperty(PropertyName = "FishChampionshipReward1", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public ItemAmount[] FishChampionshipReward1 { get; set; } = /*DefaultValue*/ { new ItemAmount
                                                                                       {
                                                                                           ItemId = 57,
                                                                                           Amount = 800000
                                                                                       } };

        ///<summary>Item Id used as reward.Item count used as reward (for the 5 first winners) - 2.</summary>
        [DefaultValue(500000)]
        [JsonProperty(PropertyName = "FishChampionshipReward2", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public ItemAmount[] FishChampionshipReward2 { get; set; } = /*DefaultValue*/ { new ItemAmount
                                                                                       {
                                                                                           ItemId = 57,
                                                                                           Amount = 500000
                                                                                       } };

        ///<summary>Item Id used as reward.Item count used as reward (for the 5 first winners) - 3.</summary>
        [DefaultValue(300000)]
        [JsonProperty(PropertyName = "FishChampionshipReward3", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public ItemAmount[] FishChampionshipReward3 { get; set; } = /*DefaultValue*/ { new ItemAmount
                                                                                       {
                                                                                           ItemId = 57,
                                                                                           Amount = 300000
                                                                                       } };

        ///<summary>Item Id used as reward.Item count used as reward (for the 5 first winners) - 4.</summary>
        [DefaultValue(200000)]
        [JsonProperty(PropertyName = "FishChampionshipReward4", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public ItemAmount[] FishChampionshipReward4 { get; set; } = /*DefaultValue*/ { new ItemAmount
                                                                                       {
                                                                                           ItemId = 57,
                                                                                           Amount = 200000
                                                                                       } };

        ///<summary>Item Id used as reward.Item count used as reward (for the 5 first winners) - 5.</summary>
        [DefaultValue(100000)]
        [JsonProperty(PropertyName = "FishChampionshipReward5", DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public ItemAmount[] FishChampionshipReward5 { get; set; } = /*DefaultValue*/ { new ItemAmount
                                                                                       {
                                                                                           ItemId = 57,
                                                                                           Amount = 100000
                                                                                       } };
    }
}