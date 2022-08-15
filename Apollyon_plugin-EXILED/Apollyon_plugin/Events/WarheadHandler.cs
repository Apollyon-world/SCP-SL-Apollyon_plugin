using Exiled.API.Enums;
using Exiled.API.Features;
using System.Linq;

namespace Apollyon_plugin.Events
{
    internal sealed class WarheadHandler
    {
        private readonly Config config = ManagerO5.Singleton.Config;

        public void OnDetonated()
        {
            if (!config.SerpentsHandModifiers.WarheadKillsInPocket)
                return;

            foreach (Player player in Player.List.Where(x => x.CurrentRoom.Type == RoomType.Pocket && API.IsSerpent(x)))
                player.Kill("Vaporizer par l'Alpha Warhead");
        }
    }
}
