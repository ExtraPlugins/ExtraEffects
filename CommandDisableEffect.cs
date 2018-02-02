using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDG.Unturned;
using Rocket.Unturned.Player;
using Rocket.Unturned.Chat;

namespace ExtraConcentratedJuice.ExtraEffects
{
    public class CommandDisableEffect : IRocketCommand
    {

        #region Properties

        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "disableEffect";

        public string Help => "Sends a player an effect.";

        public string Syntax => "/disableEffect <player> <effect>";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string> { "extraeffects.sendeffect" };

        #endregion

        public void Execute(IRocketPlayer caller, string[] args)
        {
            UnturnedPlayer c = (UnturnedPlayer)caller;
            EffectManager.sendUIEffect(54167, 1, c.CSteamID, true, "Bad meme");
        }
    }
}
