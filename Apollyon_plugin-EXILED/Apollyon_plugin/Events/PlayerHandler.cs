using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using PlayerStatsSystem;
using System.Collections.Generic;
using System.Linq;

namespace Apollyon_plugin.Events
{
    internal sealed class PlayerHandler
    {
        private readonly Config config = ManagerO5.Singleton.Config;

        public void OnFailingEscapePocketDimension(FailingEscapePocketDimensionEventArgs ev)
        {
            if (API.IsSerpent(ev.Player) && !config.SerpentsHandModifiers.FriendlyFire)
            {
                ev.IsAllowed = false;
                if (config.SerpentsHandModifiers.TeleportTo106)
                    ev.Player.Position = Extensions.Get106Position();
            }
        }

        public void OnEscapingPocketDimension(EscapingPocketDimensionEventArgs ev)
        {
            if (API.IsSerpent(ev.Player) && config.SerpentsHandModifiers.TeleportTo106)
                ev.TeleportPosition = Extensions.Get106Position();
        }

        public void OnHurting(HurtingEventArgs ev)
        {

            if (ev.Attacker == null)
                return;

            if  (((API.IsSerpent(ev.Target) && API.IsSerpent(ev.Attacker) && ev.Target != ev.Attacker)) && !config.SerpentsHandModifiers.FriendlyFire)
                ev.IsAllowed = false;
        }

        public void OnShooting(ShootingEventArgs ev)
        {
            Player target = Player.Get(ev.TargetNetId);
            if (target != null && target.Role == RoleType.Scp096 && API.IsSerpent(ev.Shooter))
                ev.IsAllowed = true;
        }

        public void OnActivatingGenerator(ActivatingGeneratorEventArgs ev)
        {
            if (API.IsSerpent(ev.Player) && !config.SerpentsHandModifiers.FriendlyFire)
                ev.IsAllowed = false;
        }

        public void OnEnteringFemurBreaker(EnteringFemurBreakerEventArgs ev)
        {
            if (API.IsSerpent(ev.Player) && !config.SerpentsHandModifiers.FriendlyFire)
                ev.IsAllowed = false;
        }

        public void OnDestroying(DestroyingEventArgs ev)
        {
            if (API.IsSerpent(ev.Player))
                Extensions.DestroySH(ev.Player);
        }

        public void OnDied(DiedEventArgs ev)
        {
            if (API.IsSerpent(ev.Target))
            {
                Extensions.DestroySH(ev.Target);
                return;
            }

            if (ev.Target.Role == RoleType.Scp106 && !config.SerpentsHandModifiers.FriendlyFire)
                foreach (Player player in Player.List.Where(x => x.CurrentRoom.Type == RoomType.Pocket))
                    player.Hurt(new CustomReasonDamageHandler("WORLD", 50000f));
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (API.IsSerpent(ev.Player) && ev.NewRole != RoleType.FacilityGuard)
                Extensions.DestroySH(ev.Player);
        }

        public void OnSpawningRagdoll(SpawningRagdollEventArgs ev)
        {
            if (!API.IsSerpent(ev.Owner))
                return;

            ev.IsAllowed = false;

            RagdollInfo info = new RagdollInfo(Server.Host.ReferenceHub, ev.DamageHandlerBase, ev.Role, ev.Position, ev.Rotation, ev.Nickname, ev.CreationTime);
            new Exiled.API.Features.Ragdoll(info, true);
        }
    }
}
