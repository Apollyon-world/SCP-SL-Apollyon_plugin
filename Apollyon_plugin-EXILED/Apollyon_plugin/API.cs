using Exiled.API.Features;
using System.Collections.Generic;
using System.Linq;

namespace Apollyon_plugin
{
    public static class API
    {
        /// <summary>
        /// Checks if <see cref="Player"/> is Manager O5.
        /// </summary>
        /// <param name="player"> The player to check.</param>
        /// <returns><see langword="true"/> if player is Manager O5, <see langword="false"/> if not.</returns>
        public static bool IsSerpent(Player player) => player.SessionVariables.ContainsKey("IsSH");

        /// <summary>
        /// Spawns <see cref="Player"/> as Manager O5.
        /// </summary>
        /// <param name="player"> The player to spawn.</param>
        /// <param name="full"> Should items and ammo be given to spawned <see cref="Player"/>.</param>
        public static void SpawnPlayer(Player player, bool full = true) => Extensions.SpawnPlayer(player, full);

        /// <summary>
        /// Spawns Manager O5 squad.
        /// </summary>
        /// <param name="playerList"> List of players to spawn.</param>
        public static void SpawnSquad(List<Player> playerList) => Extensions.SpawnSquad(playerList);

        /// <summary>
        /// Spawns Manager O5 squad.
        /// </summary>
        /// <param name="size"> The number of players in squad (this can be lower due to not enough number of Spectators).</param>
        public static void SpawnSquad(uint size) => Extensions.SpawnSquad(size);

        /// <summary>
        /// Gets all alive Manager O5 players.
        /// </summary>
        /// <returns><see cref="List{Player}"/> of all alive Manager O5 players.</returns>
        public static List<Player> GetSHPlayers() => Player.List.Where(x => x.SessionVariables.ContainsKey("IsSH")).ToList();
    }
}
