﻿using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Server = Exiled.Events.Handlers.Server;

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
        }

        public void UnregisterEvents()
        {
            Server.WaitingForPlayers -= server.OnWaitingForPlayers;
            Server.RoundStarted -= server.OnRoundStarted;

            server = null;
        }
    }
}