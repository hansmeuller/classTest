using System;
using System.Collections.Generic;
using System.IO;
using NUnit;

namespace klassenTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // pfad
            string filePath = "C:/unittest.csv";

            // einlesen
            var entries = CsvReader.ReadCsv(filePath);

            // verarbeiten
            var mapController = new MapController();
            mapController.ProcessMapEntries(entries);

            // polls diesdas
            var activePolls = mapController.GetActivePolls();
            Console.WriteLine("Active Polls:");
            foreach (var pol in activePolls)
            {
                Console.WriteLine($"ProviderID: {pol.ProviderID}, AmountNQT: {pol.AmountNQT}, IsEntitled: {pol.IsEntitled}, Timeout: {pol.Timeout}");
            }
        }
    }
}
