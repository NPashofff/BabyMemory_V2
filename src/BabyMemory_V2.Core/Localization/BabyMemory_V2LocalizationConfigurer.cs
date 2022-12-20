using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace BabyMemory_V2.Localization
{
    public static class BabyMemory_V2LocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BabyMemory_V2Consts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BabyMemory_V2LocalizationConfigurer).GetAssembly(),
                        "BabyMemory_V2.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
