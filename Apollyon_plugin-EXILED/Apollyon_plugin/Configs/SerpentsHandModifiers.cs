using Exiled.API.Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace Apollyon_plugin.Configs
{
    public class SerpentsHandModifiers
    {
        [Description("Determines role name seen ingame (Supports Colors)")]
        public string RoleName { get; set; } = "Manageur O5";

        [Description("The amount of health Manager O5 has.")]
        public float Health { get; set; } = 160f;

        [Description("The amount of armor Manager O5 has.")]
        public float Armor { get; set; } = 200f;

        [Description("The items Manager O5 spawn with. (supports CustomItems)")]
        public List<string> SpawnItems { get; set; } = new List<string>
        {
            "GunLogicer",
            "KeycardO5",
            "GrenadeHE",
            "Radio",
            "Medkit",
            "ArmorHeavy",
            "Adrenaline",
            "Flashlight"
        };

        [Description("The ammo Manager O5 spawn with.")]
        public Dictionary<AmmoType, ushort> SpawnAmmo { get; set; } = new Dictionary<AmmoType, ushort>()
        {
            { AmmoType.Nato556, 0 },
            { AmmoType.Nato762, 200 },
            { AmmoType.Nato9, 0 },
            { AmmoType.Ammo12Gauge, 0 },
            { AmmoType.Ammo44Cal, 0 },
        };

        [Description("Determines if friendly fire between Manager O5 and SCPs is enabled")]
        public bool FriendlyFire { get; set; } = true;

        [Description("Determines if Manager O5 should teleport to SCP-106 after exiting his pocket dimension")]
        public bool TeleportTo106 { get; set; } = false;

        [Description("Determines if Manager O5 should be killed within the pocket dimension when the warhead detonates.")]
        public bool WarheadKillsInPocket { get; set; } = false;

        [Description("Set this to false if Chaos and SCPs CANNOT win together on your server")]
        public bool ScpsWinWithChaos { get; set; } = false;
    }
}
