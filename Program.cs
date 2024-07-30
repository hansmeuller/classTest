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

            //where's jonny
            if (!File.Exists(filePath))
            {
                Console.WriteLine("keine csv da");
            }


            // einlesen
            var entries = CsvReader.ReadCsv(filePath);

            //test reading
            if (entries.Count == 0)
            {
                Console.WriteLine("kein inhalt in der csv");
            }

            //show
            Console.WriteLine("inhalt: ");
            foreach (var entry in entries)
            {
                Console.WriteLine($"Key1: {entry.Key1}, Key2: {entry.Key2}, Value: {entry.Value}");

            }

            // verarbeiten
            var mapController = new MapController();
            mapController.ProcessMapEntries(entries);

            // polls diesdas
            var activePolls = mapController.GetActivePolls();
            Console.WriteLine("Active Polls:");
            if (activePolls.Count == 0)
            {
                Console.WriteLine("Keine aktiven Polls gefunden.");
            }
            else
            {
                foreach (var pol in activePolls)
                {
                    Console.WriteLine($"ProviderID: {pol.ProviderID}, AmountNQT: {pol.AmountNQT}, IsEntitled: {pol.IsEntitled}, Timeout: {pol.Timeout}");
                }
            }
            //alle polls anzeigen
            var allPolls = mapController.GetAllPolls();
            Console.WriteLine("alle polls: ");
            if (allPolls.Count == 0)
            {
                Console.WriteLine("keine polls gefunden.");
            }
            else
            {
                foreach (var poll in allPolls)
                {
                    Console.WriteLine($"ProviderID: {poll.ProviderID}, AmountNQT: {poll.AmountNQT}, IsEntitled: {poll.IsEntitled}, Timeout: {poll.Timeout}");
                }
            }
        }
    }
}
