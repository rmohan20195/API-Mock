using LINQtoCSV;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace capredv2.backend.domain.ExtensionMethods
{
    public static class CsvExtensionMethods
    {
        public static IEnumerable<T> GetCsvValues<T>(MemoryStream memoryStream) where T : class, new()
        {
            IEnumerable<T> returnValues;
            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true,
                IgnoreUnknownColumns = true,
                IgnoreTrailingSeparatorChar = true
            };
            CsvContext csvContext = new CsvContext();
            StreamReader reader = new StreamReader(memoryStream, Encoding.UTF8, true);
            returnValues = csvContext.Read<T>(reader, inputFileDescription);
            return returnValues;
        }
    }
}
