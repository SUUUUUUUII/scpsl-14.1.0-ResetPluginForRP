using System;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Loader.Features.Plugins;
using PlayerRoles;

namespace HUD
{
    public class Class1 : Plugin

    {
        public override string Name => "ResetPlugin";
        public override string Description => "Reset RP names After death or changing role";
        public override string Author => "IIIAuPMa";
        public override Version Version => new Version(1, 4);
        public override Version RequiredApiVersion => new Version(1, 3);
        public override void Disable()
        {
            LabApi.Events.Handlers.PlayerEvents.ChangedRole -= ResetNicknames;
        }
        public override void Enable()
        {
            LabApi.Events.Handlers.PlayerEvents.ChangedRole += ResetNicknames;
        }
        public void ResetNicknames(PlayerChangedRoleEventArgs ev)
        {
            if (ev.Player.Role != RoleTypeId.CustomRole)
            {
                ev.Player.DisplayName = ev.Player.Nickname;
            }
        }
    }
}
