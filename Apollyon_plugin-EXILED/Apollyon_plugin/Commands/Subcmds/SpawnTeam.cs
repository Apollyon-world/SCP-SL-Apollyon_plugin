using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;
using System.Linq;

namespace Apollyon_plugin.Commands.Subcmds
{
    public class SpawnTeam : ICommand
    {
        public string Command { get; } = "spawnteam";
        public string[] Aliases { get; } = { "st" };
        public string Description { get; } = "Spawn Manageur O5 team.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("MO.spawnteam"))
            {
                response = "You don't have permission to execute this command. Required permission: MO.spawnteam";
                return false;
            }

            int validPlayers = Player.List.Where(x => x.Role.Team == Team.RIP && !x.IsOverwatchEnabled).Count();

            if (arguments.Count == 0)
            {
                uint maxSquad = ManagerO5.Singleton.Config.SpawnManager.MaxSquad;
                if (validPlayers >= maxSquad)
                {
                    API.SpawnSquad(maxSquad);
                    response = $"Manager O5 squad with {maxSquad} players has been spawned.";
                    return true;
                }
                response = $"There is not enough Spectators to spawn Manager O5 squad with {maxSquad} players. Required {maxSquad - validPlayers} more.";
                return false;
            }

            if (!uint.TryParse(arguments.At(0), out uint num) || num == 0)
            {
                response = $"'{num}' is not a valid number.";
                return false;
            }

            if (validPlayers >= num)
            {
                API.SpawnSquad(num);
                response = $"Manager O5 squad with {num} players has been spawned.";
                return true;
            }

            response = $"There is not enough Spectators to spawn Manager O5 squad with {num} players. Required {num - validPlayers} more.";
            return false;
        }
    }
}
