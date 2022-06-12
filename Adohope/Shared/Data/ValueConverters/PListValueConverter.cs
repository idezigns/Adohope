using Adohope.Shared.Utils;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.IO;
using System.Linq.Expressions;

namespace Adohope.Shared.Data.ValueConverters
{
    public class PListValueConverter : ValueConverter<Adohope.Shared.PList.DynamicPList, byte[]>
    {
        public PListValueConverter(ConverterMappingHints mappingHints = null) : base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
        {
        }

        private static Expression<Func<Adohope.Shared.PList.DynamicPList, byte[]>> convertToProviderExpression = x
            => ToByteArray(x);

        private static Expression<Func<byte[], Adohope.Shared.PList.DynamicPList>> convertFromProviderExpression = x 
            => new Adohope.Shared.PList.DynamicPList(x);

        public static byte[] ToByteArray(Adohope.Shared.PList.DynamicPList x)
        {
            //todo: Move this logic to PList class
            MemoryStream ms = new MemoryStream();
            PListUtils.Save(ms, x.RootNode, PListNet.PListFormat.Binary);
            return ms.ToArray();
        }
    }
}
