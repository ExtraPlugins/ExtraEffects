using Rocket.Core.Plugins;
using com.aviadmini.rocketmod.AviEconomy;
using com.aviadmini.rocketmod.AviRockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace ExtraConcentratedJuice.ExtraEffects
{
    public class ExtraEffects : RocketPlugin<ExtraEffectsConfig>
    {
        private static DateTime lastUpdated;
        public static ExtraEffects Instance;

        protected override void Load()
        {
            Instance = this;
            lastUpdated = DateTime.Now;

            PlayerEvents.OnPlayerRepUpd += UIManager.UpdateReputation;
            U.Events.OnPlayerConnected += OnConnection;
        }

        private void FixedUpdate()
        {
            // "Public Developer API" without events ok AviRocket

            if ((DateTime.Now - lastUpdated).Seconds > Util.getConfig().updateInterval)
                for (int i = 0; i < Provider.clients.Count; i++)
                {
                    UIManager.UpdateBalance(UPlayer.From(Provider.clients[i]));
                }
        }

        private void OnConnection(UnturnedPlayer player)
        {
            UIManager.UpdateBalance(UPlayer.From(player));
            UIManager.UpdateReputation(UPlayer.From(player), player.Reputation);
        }
    }
}
