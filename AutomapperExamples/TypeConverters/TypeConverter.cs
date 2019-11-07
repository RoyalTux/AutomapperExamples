using System;
using AutoMapper;
using static System.Console;

// ReSharper disable IdentifierTypo
namespace AutomapperExamples.TypeConverters
{
    public class TypeConverter
    {
        public void TestCustomConverter()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Source, Destination>();
                cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
                cfg.CreateMap<string, DateTime>().ConvertUsing<DateTimeTypeConverter>();
            });

            var source = new Source { Number = "55", Date = "01/01/2019" };
            var dest = Mapper.Map<Destination>(source);

            WriteLine(dest.Number == 55);
            WriteLine(dest.Date == new DateTime(2019, 1, 1));

            ReadLine();
        }
    }

    public class Source
    {
        public string Number { get; set; }
        public string Date { get; set; }
    }

    public class Destination
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
    }

    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            return System.Convert.ToDateTime(source);
        }
    }
}
