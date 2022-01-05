using ServiceCenterBackend.Enum;
using System.Collections.Generic;

namespace ServiceCenterBackend.Rules
{
    public static class ProviderSelectionRule
    {
        public static List<string []> GetPriorities(CategoryEnum category, LanguageLevelEnum languageLevel) 
        {
            List<string []> priorities = new List<string []>();

            if (category == CategoryEnum.Hardware && languageLevel == LanguageLevelEnum.SpeaksBahasa)
            {
                priorities.Add(new string[] { "A", "B" });
                priorities.Add(new string[] { "B" });
            }
            if (category == CategoryEnum.Network && languageLevel == LanguageLevelEnum.SpeaksBahasa)
            {
                priorities.Add(new string[] { "A", "C" });
                priorities.Add(new string[] { "C" });
            }
            if (category == CategoryEnum.Software && languageLevel == LanguageLevelEnum.Regardless)
            {
                priorities.Add(new string[] { "D" });
            }
            if (category == CategoryEnum.Hardware && languageLevel == LanguageLevelEnum.DontSpeakBahasa)
            {
                priorities.Add(new string[] { "B" });
            }
            if (category == CategoryEnum.Network && languageLevel == LanguageLevelEnum.DontSpeakBahasa)
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
