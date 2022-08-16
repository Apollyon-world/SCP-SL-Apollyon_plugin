using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

namespace Apollyon_plugin.Commands.Subcmds
{
    public class List : ICommand
    {
        public string Command { get; } = "list";
        public string[] Aliases { get; } = { "l" };
        public string Description { get; } = "Shows a list with players that are currently Manager O5.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("MO.list"))
            {
                response = "You don't have permission to execute this command. Required permission: MO.list";
                return false;
            }

            response = "\nList of players that are currently Manager O5:\n";

            foreach (Player sHPlayer in API.GetSHPlayers())
                response += $"- ({sHPlayer.Id}) {sHPlayer.Nickname}\n";

            return true;
        }
    }
}
