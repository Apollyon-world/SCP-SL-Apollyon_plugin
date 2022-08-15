using Exiled.API.Enums;
using Exiled.API.Features;
using System.Linq;

namespace Apollyon_plugin.Events
{
    internal sealed class WarheadHandler
    {
        private readonly Config config = ManagerO5.Singleton.Config;

        public void CanBeStarted()
        {
            Cassie.MessageTranslated(".g6 .g6 .g6 .g6 .g6 .g6 System warhead can be activated . . . Standby for the activation of the nuclear jam_045_07 warhead .g4 .g4", "Le système nucléaire peut être activer, En attente de l'activation de l'ogive nucléaire.", true, true, true);
        }

        public void IsKeycardActivated()
        {
            Cassie.MessageTranslated(".g6 .g6 .g6 .g6 .g6 .g6 Attention keycard warhead surface has been open .g4 .g4", "Attention le cache de protection de l'ogive en surface vient d'être ouvert.", true, true, true);
        }

        public void OnDetonated()
        {
            if (!config.SerpentsHandModifiers.WarheadKillsInPocket)
                return;

            foreach (Player player in Player.List.Where(x => x.CurrentRoom.Type == RoomType.Pocket && API.IsSerpent(x)))
                player.Kill("Vaporizer par l'Alpha Warhead");
        }
    }
}
