using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtraConcentratedJuice.ExtraEffects
{
    public static class Util
    {
        public static ExtraEffectsConfig getConfig() => ExtraEffects.Instance.Configuration.Instance;

        public static string Translate(string TranslationKey, params object[] Placeholders) =>
            ExtraEffects.Instance.Translations.Instance.Translate(TranslationKey, Placeholders);
    }
}
