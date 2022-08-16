using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;
using FB106 = Exiled.Events.Handlers.Player;

namespace Apollyon_plugin
{
    public class Apollyon_plugin : Plugin<Config>
    {
        private static readonly Lazy<Apollyon_plugin> LazyInstance = new Lazy<Apollyon_plugin>(() => new Apollyon_plugin());
        public static Apollyon_plugin Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.Server server;

        private Apollyon_plugin()
        {
        }

        public override void OnEnabled()
        {
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        public void RegisterEvents()
        {
            server = new Handlers.Server();

            Server.WaitingForPlayers += server.OnWaitingForPlayers;
            Server.RoundStarted += server.OnRoundStarted;
            Warhead.ChangingLeverStatus += server.OnChangingLeverStatus;
            FB106.EnteringFemurBreaker += server.OnEnteringFemurBreakerEventArgs;
        }

        public void UnregisterEvents()
        {
            Server.WaitingForPlayers -= server.OnWaitingForPlayers;
            Server.RoundStarted -= server.OnRoundStarted;
            Warhead.ChangingLeverStatus -= server.OnChangingLeverStatus;
            FB106.EnteringFemurBreaker -= server.OnEnteringFemurBreakerEventArgs;

            server = null;
        }
    }
}