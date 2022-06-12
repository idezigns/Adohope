using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;

namespace Adohope.Shared.Data.ValueConverters
{
    public class DynamicPListValueConverter : ValueConverter<dynamic, byte[]>
    {
        public DynamicPListValueConverter(ConverterMappingHints mappingHints = null) : 
            base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
        {
        }

        private static Expression<Func<dynamic, byte[]>> convertToProviderExpression = x 
            => PListValueConverter.ToByteArray(x as Adohope.Shared.PList.DynamicPList);

        private static Expression<Func<byte[], dynamic>> convertFromProviderExpression = x 
            => new Adohope.Shared.PList.DynamicPList(x);
    }
}
