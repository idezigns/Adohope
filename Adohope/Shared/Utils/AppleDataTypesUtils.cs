using System;
using System.Collections.Generic;
using System.Text;

namespace Adohope.Shared.Utils
{
    public static class AppleDataTypesUtils
    {
        public static DateTime UnixTimeToDateTime(long timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
        }

        public static DateTime CFTimeIntervalToDateTime(double timestamp, bool convertFromUtcToLocalTimeZone = true)
        {
            // =======================================================================
            //
            // Resources:
            // https://developer.apple.com/documentation/corefoundation/cfabsolutetime
            // https://developer.apple.com/documentation/corefoundation/cftimeinterval
            // https://www.epochconverter.com/coredata
            //
            // =======================================================================

            if (timestamp > 1000000000)
            {
                var datetime1 = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp / 1000000000 + 978307200);
                return datetime1.ToLocalTime();
            }
            
            if(timestamp == 0)
            {
                var datetime2 = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp + 978307200);
                return datetime2.ToLocalTime();
            }

            var datetime3 = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);

            return datetime3.ToLocalTime();
        }

        public static long DateTimeToCFTimeInterval(DateTime dateTime)
        {
            var different =  dateTime.ToUniversalTime().Ticks - new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

            return takeNDigits(different, 9);
        }

        // Credit: https:{/}{/}ww{w}.c-sharpcorner{dot}com/blogs/how-to-get-first-n-digits-of-a-number
        //todo: re-write the method
        private static long takeNDigits(double number, long N)
        {
            // this is for handling negative numbers, we are only insterested in postitve number
            number = Math.Abs(number);
            // special case for 0 as Log of 0 would be infinity
            if (number == 0)
                return (long)number;
            // getting number of digits on this input number
            int numberOfDigits = (int)Math.Floor(Math.Log10(number) + 1);
            // check if input number has more digits than the required get first N digits
            if (numberOfDigits >= N)
                return (long)Math.Truncate((number / Math.Pow(10, numberOfDigits - N)));
            else
                return (long)number;
        }
    }
}
