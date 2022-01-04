using ServiceCenterBackend.Enum;
using System.Collections.Generic;

namespace ServiceCenterBackend.Rules
{
    public static class ProviderSelectionRule
    {
        public static List<string []> GetPriorities(string category, LanguageLevelEnum languageLevel) 
        {
            List<string []> priorities = new List<string []>();

            if (category == "Hardware" && languageLevel == LanguageLevelEnum.SpeaksBahasa)
            {
                priorities.Add(new string[] { "A", "B" });
                priorities.Add(new string[] { "B" });
            }
            if (category == "Network" && languageLevel == LanguageLevelEnum.SpeaksBahasa)
            {
                priorities.Add(new string[] { "A", "C" });
                priorities.Add(new string[] { "C" });
            }
            if (category == "Software" && languageLevel == LanguageLevelEnum.Regardless)
            {
                priorities.Add(new string[] { "D" });
            }
            if (category == "Hardware" && languageLevel == LanguageLevelEnum.DontSpeakBahasa)
            {
                priorities.Add(new string[] { "B" });
            }
            if (category == "Network" && languageLevel == LanguageLevelEnum.DontSpeakBahasa)
            {
                priorities.Add(new string[] { "C" });
            }
            if (languageLevel == LanguageLevelEnum.SpeaksBahasa)
            {
                priorities.Add(new string[] { "A" });
            }

            return priorities;

        }
    }
}
