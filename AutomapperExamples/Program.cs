using AutomapperExamples.Profiles;
using AutomapperExamples.TypeConverters;
using AutomapperExamples.ValueConverters;

// ReSharper disable IdentifierTypo
namespace AutomapperExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var automapperProfiles = new AutomapperProfiles();
            automapperProfiles.TestAutomapperProfile();

            var typeConverter = new TypeConverter();
            typeConverter.TestCustomConverter();

            var valueConverter = new ValueConverter();
            valueConverter.TestValueConverter();
        }
    }
}
