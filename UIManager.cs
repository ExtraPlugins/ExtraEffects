using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDG.Unturned;
using com.aviadmini.rocketmod.AviRockets;
using Rocket.Unturned.Player;
using Steamworks;
using com.aviadmini.rocketmod.AviEconomy;
using System.Reflection;

namespace ExtraConcentratedJuice.ExtraEffects
{
    public static class UIManager
    {
        public static void UpdateReputation(UPlayer player, int rep)
        {
            EffectManager.sendUIEffect(
                GetEffect(EffectType.REPUTATION),
                (short)EffectType.REPUTATION,
                GetCSteamID(player),
                true,
                rep.ToString());
        }

        /*
        public static void UpdateSalary(UPlayer player)
        {
            EffectManager.sendUIEffect(
                GetEffect(EffectType.SALARY),
                (short)EffectType.SALARY,
                GetCSteamID(player),
                true,
                Bank.GetBalance(player.Id).ToString());
        } */

        public static void UpdateBalance(UPlayer player)
        {
            EffectManager.sendUIEffect(
                GetEffect(EffectType.MONEY),
                (short)EffectType.MONEY,
                GetCSteamID(player),
                true,
                Bank.GetBalance(player.Id).ToString());
        }


        public static CSteamID GetCSteamID(Player player) => player.channel.owner.playerID.steamID;
        public static CSteamID GetCSteamID(UnturnedPlayer player) => player.Player.channel.owner.playerID.steamID;
        public static CSteamID GetCSteamID(UPlayer player) => player.Player.channel.owner.playerID.steamID;

        public static ushort GetEffect(EffectType type)
        {
            ushort id = 0;

            switch (type)
            {
                case EffectType.REPUTATION:
                    id = Util.getConfig().reputationEffectId;
                    break;
                case EffectType.MONEY:
                    id = Util.getConfig().moneyEffectId;
                    break;
                case EffectType.SALARY:
                    id = Util.getConfig().salaryEffectId;
                    break;
            }

            return id;
        }

        public static string GetReputation(int rep)
        {
            // I stole this from Nelson's code lol
            string result = String.Empty;
            if (rep <= -200)
                result = "Villain";
            else if (rep <= -100)
                result = "Bandit";
            else if (rep <= -33)
                result = "Gangster";
            else if (rep <= -8)
                result = "Outlaw";
            else if (rep < 0)
                result = "Thug";
            else if (rep >= 200)
                result = "Paragon";
            else if (rep >= 100)
                result = "Sheriff";
            else if (rep >= 33)
                result = "Deputy";
            else if (rep >= 8)
                result = "Constable";
            else if (rep > 0)
                result = "Vigilante";
            else if (rep == 0)
                result = "Neutral";
            return result;
        }

        public enum EffectType : short
        {
            REPUTATION,
            MONEY,
            SALARY
        }
    }
}
