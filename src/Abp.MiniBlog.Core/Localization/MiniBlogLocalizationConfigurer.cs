using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Abp.MiniBlog.Localization
{
    public static class MiniBlogLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MiniBlogConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MiniBlogLocalizationConfigurer).GetAssembly(),
                        "Abp.MiniBlog.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
