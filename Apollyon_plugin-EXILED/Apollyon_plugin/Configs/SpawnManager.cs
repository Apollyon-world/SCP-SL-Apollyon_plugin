namespace Apollyon_plugin.Configs
{
    using Exiled.API.Features;
    using System.Collections.Generic;
    using System.ComponentModel;
    using UnityEngine;

    public class SpawnManager
    {
        [Description("The chance for Manager O5 to spawn instead of other role.")]
        public int SpawnChance { get; set; } = 50;

        [Description("The maximum size of a Manager O5 squad.")]
        public uint MaxSquad { get; set; } = 2;

        [Description("How many respawn waves must occur before considering Manager O5 to spawn.")]
        public int RespawnDelay { get; set; } = 1;

        [Description("The maximum number of times Manager O5 can spawn per game.")]
        public int MaxSpawns { get; set; } = 3;

        [Description("Determines if Manager O5 should be able to spawn when there is no SCPs.")]
        public bool CanSpawnWithoutScps { get; set; } = true;

        [Description("The message annouced by CASSIE when Manager O5 spawn. (Empty = Disabled)")]
        public string EntryAnnoucement { get; set; } = "Manager O5 HASENTERED";

        [Description("The message annouced by CASSIE when Chaos spawn. (Empty = Disabled)")]
        public string ChaosEntryAnnoucement { get; set; } = "CHAOSINSURGENCY HASENTERED";

        [Description("The broadcast sent to Manager O5 when they spawn.")]
        public Broadcast SpawnBroadcast { get; set; } = new Broadcast("<size=60>Tu es <color=#03F555><b>Manageur O5</b></color></size>\n<i>Aide le <color=\"red\">personnel</color> .</i>");

        [Description("The broadcast shown to everyone when the Manager O5 respawns.")]
        public Broadcast EntryBroadcast { get; set; } = new Broadcast("<color=orange>Les Manageurs O5 sont entrés dans le site !</color>");

        [Description("The Manager O5 spawn position.")]
        public Vector3 SpawnPos { get; set; } = new Vector3(0f, 1002f, 8f);

        [Description("The Manager O5 Unit Names")]
        public List<string> UnitNames { get; set; } = new List<string>
        {
            "MO5-Alpha 4",
            "MO5-Beta 1",
            "MO5-Cierra 5"
        };
    }
}
