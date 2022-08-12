using Exiled.Events.EventArgs;

namespace Apollyon_plugin.Events
{
    internal sealed class Scp106Handler
    {
        private Config config = ManagerO5.Singleton.Config;

        public void OnContaining(ContainingEventArgs ev)
        {
            if (API.IsSerpent(ev.Player) && !config.SerpentsHandModifiers.FriendlyFire)
                ev.IsAllowed = false;
        }
    }
}
