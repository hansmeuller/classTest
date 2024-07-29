using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace klassenTest
{
    public class CsvReader
    {
        public static List<MapEntry> ReadCsv(string filePath)
        {
            var entries = new List<MapEntry>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split('\t');
                if (parts.Length == 3)
                {
                    var entry = new MapEntry
                    {
                        Key1 = int.Parse(parts[0], CultureInfo.InvariantCulture),
                        Key2 = int.Parse(parts[1], CultureInfo.InvariantCulture),
                        Value = long.Parse(parts[2], CultureInfo.InvariantCulture)
                    };
                    entries.Add(entry);
                }
            }
            return entries;
        }
    }
}
