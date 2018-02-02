using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtraConcentratedJuice.ExtraEffects
{
    public class ExtraEffectsConfig : IRocketPluginConfiguration
    {
        public ushort reputationEffectId;
        public ushort salaryEffectId;
        public ushort moneyEffectId;
        public int updateInterval;

        public void LoadDefaults()
        {
            reputationEffectId = 54167;
            salaryEffectId = 54168;
            moneyEffectId = 54165;
            updateInterval = 5;
        }
    }
}
