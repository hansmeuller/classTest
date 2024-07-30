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
                var parts = line.Split(';');
                if (parts.Length == 3)
                {
                    try
                    {
                                         
                            var key1 = long.Parse(parts[0], CultureInfo.InvariantCulture);
                            var key2 = long.Parse(parts[1], CultureInfo.InvariantCulture);
                            var value = long.Parse(parts[2], CultureInfo.InvariantCulture);

                        var entry = new MapEntry
                        {
                            Key1 = key1,
                            Key2 = key2,
                            Value = value
                        };
                        
                        entries.Add(entry);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"fail beim verarbeiten: {line}. fail: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"nope: {line}");
                }
            }
            return entries;
        }
    }
}
