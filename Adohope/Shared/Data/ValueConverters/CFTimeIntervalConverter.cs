using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;

namespace Adohope.Shared.Data.ValueConverters
{
    public class CFTimeIntervalConverter : ValueConverter<DateTime, string>
    {
        public CFTimeIntervalConverter(ConverterMappingHints mappingHints = null) 
            : base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
        {
        }

        private static Expression<Func<DateTime, string>> convertToProviderExpression = x => ConvertTo(x);

        private static Expression<Func<string, DateTime>> convertFromProviderExpression = x => ConvertFrom(x);

        public static string ConvertTo(DateTime x)
        {
            return AppleDataTypesUtils.DateTimeToCFTimeInterval(x).ToString();
        }
        public static DateTime ConvertFrom(string x)
        {
            return AppleDataTypesUtils.CFTimeIntervalToDateTime(double.Parse(x));
        }
    }
}
