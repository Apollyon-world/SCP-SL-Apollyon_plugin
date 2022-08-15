using Exiled.API.Features;
using HarmonyLib;
using PlayableScps;
using UnityEngine;

namespace Apollyon_plugin.Patches
{
    [HarmonyPatch(typeof(Scp939), nameof(Scp939.ServerAttack))]
    public class Scp939ServerAttack
    {
        public static void Postfix(Scp939 __instance, GameObject target)
        {
            Player player = Player.Get(target);
            if (player != null && API.IsSerpent(player) && !ManagerO5.Singleton.Config.SerpentsHandModifiers.FriendlyFire)
                player.ReferenceHub.playerEffectsController.DisableEffect<CustomPlayerEffects.Amnesia>();
        }
    }
}
