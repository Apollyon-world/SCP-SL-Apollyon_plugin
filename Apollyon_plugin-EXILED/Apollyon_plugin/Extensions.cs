using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.CustomItems.API;
using MEC;
using Respawning;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Apollyon_plugin
{
    internal static class Extensions
    {
        private static Config Config => ManagerO5.Singleton.Config;
        private static ManagerO5 Plugin => ManagerO5.Singleton;

        public static int CountRoles(Team team) => Player.List.Where(x => x.Role.Team == team && !x.SessionVariables.ContainsKey("IsNPC")).Count();

        public static void SpawnPlayer(Player player, bool full = true)
        {
            player.SessionVariables.Add("IsMO", null);
            player.Role.Type = RoleType.FacilityGuard;
            player.Health = Config.SerpentsHandModifiers.Health;
            player.MaxHealth = (int)Config.SerpentsHandModifiers.Health;
            player.ArtificialHealth = Config.SerpentsHandModifiers.Armor;
            player.MaxArtificialHealth = (int)Config.SerpentsHandModifiers.Armor;
            player.UnitName = Config.SpawnManager.UnitNames[UnityEngine.Random.Range(0, Config.SpawnManager.UnitNames.Count)];
            player.CustomInfo = Config.SerpentsHandModifiers.RoleName;

            player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.Nickname;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.UnitName;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.Role;

            player.Broadcast(Config.SpawnManager.SpawnBroadcast);

            if (full)
            {
                Timing.CallDelayed(0.4f, () =>
                {
                    player.ResetInventory(Config.SerpentsHandModifiers.SpawnItems);
                    foreach (var ammo in Config.SerpentsHandModifiers.SpawnAmmo)
                        player.Ammo[ammo.Key.GetItemType()] = ammo.Value;
                });
            }
            Timing.CallDelayed(1.7f, () => player.Position = Config.SpawnManager.SpawnPos);
        }

        public static void DestroySH(Player player)
        {
            player.SessionVariables.Remove("IsSH");
            player.MaxHealth = default;
            player.Health = default;
            player.MaxArtificialHealth = default;
            player.ArtificialHealth = default;
            player.CustomInfo = string.Empty;
            player.UnitName = string.Empty;

            player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.Nickname;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.UnitName;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.Role;
        }

        public static void SpawnSquad(uint size)
        {
            List<Player> spec = Player.List.Where(x => x.Role.Team == Team.RIP && !x.IsOverwatchEnabled).ToList();
            bool prioritySpawn = RespawnManager.Singleton._prioritySpawn;

            if (prioritySpawn)
                spec.OrderBy(x => x.ReferenceHub.characterClassManager.DeathTime);

            int spawnCount = 1;
            while (spec.Count > 0 && spawnCount <= size)
            {
                int index = UnityEngine.Random.Range(0, spec.Count);
                if (spec[index] == null)
                    continue;

                SpawnPlayer(spec[index]);
                spec.RemoveAt(index);
                spawnCount++;
            }

            if (spawnCount > 0 && !string.IsNullOrEmpty(Config.SpawnManager.EntryAnnoucement))
                Cassie.GlitchyMessage(Config.SpawnManager.EntryAnnoucement, 0.05f, 0.05f);

            foreach (Player scp in Player.List.Where(x => x.Role.Team == Team.SCP || x.SessionVariables.ContainsKey("IsScp035")))
                scp.Broadcast(Config.SpawnManager.EntryBroadcast);
        }

        public static void SpawnSquad(List<Player> players)
        {
            foreach (Player player in players)
                SpawnPlayer(player);

            if (players.Count > 0)
                Cassie.GlitchyMessage(Config.SpawnManager.EntryAnnoucement, 0.05f, 0.05f);

            foreach (Player scp in Player.List.Where(x => x.Role.Team == Team.SCP || x.SessionVariables.ContainsKey("IsScp035")))
                scp.Broadcast(Config.SpawnManager.EntryBroadcast);
        }

        public static Vector3 Get106Position()
        {
            Player scp106 = Player.List.FirstOrDefault(x => x.Role == RoleType.Scp106);
            if (scp106 == null) return RoleType.Scp096.GetRandomSpawnProperties().Item1;
            return scp106.Position;
        }

        public static void CalculateChance()
        {

            Plugin.IsSpawnable = UnityEngine.Random.Range(0, 101) <= Config.SpawnManager.SpawnChance &&
                Plugin.TeamRespawnCount >= Config.SpawnManager.RespawnDelay &&
                Plugin.SerpentsRespawnCount < Config.SpawnManager.MaxSpawns &&
                !(!Config.SpawnManager.CanSpawnWithoutScps && Player.Get(Team.SCP).Count() == 0);

            Log.Debug($"Is Manager O5 team now spawnable?: {Plugin.IsSpawnable}", Config.Debug);
        }
    }
}
