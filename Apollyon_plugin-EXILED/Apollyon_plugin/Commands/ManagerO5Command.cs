using Apollyon_plugin.Commands.Subcmds;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

namespace Apollyon_plugin.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ManagerO5Command : ParentCommand
    {
        public ManagerO5Command() => LoadGeneratedCommands();

        public override string Command => "MO";
        public override string[] Aliases => Array.Empty<string>();
        public override string Description => "Parent command for Manager O5";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new List());
            RegisterCommand(new Spawn());
            RegisterCommand(new SpawnTeam());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            response = "\nPlease enter a valid subcommand:\n";
            foreach (var command in AllCommands)
                if (player.CheckPermission($"MO.{command.Command}"))
                    response += $"- {command.Command} ({string.Join(", ", Aliases)})";
            return true;
        }
    }
}
