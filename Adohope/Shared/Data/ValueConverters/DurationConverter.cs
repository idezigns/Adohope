using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;

namespace Adohope.Shared.Data.ValueConverters
{
    public class DurationConverter : ValueConverter<TimeSpan, double>
    {
        public DurationConverter(ConverterMappingHints mappingHints = null) 
            : base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
        {
        }

        private static Expression<Func<TimeSpan, double>> convertToProviderExpression = x => ConvertTo(x);

        private static Expression<Func<double, TimeSpan>> convertFromProviderExpression = x => ConvertFrom(x);

        public static double ConvertTo(TimeSpan x)
        {
            return x.TotalSeconds;
        }
        public static TimeSpan ConvertFrom(double x)
        {
            x = Math.Ceiling(x);

            return TimeSpan.FromSeconds(x);
        }
    }
}
