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

            Console.WriteLine("All Entries:");
            foreach (var entry in entries)
            {
                Console.WriteLine($"Key1: {entry.Key1}, Key2: {entry.Key2}, Value: {entry.Value}");
            }

            Console.WriteLine("All Polls:");
            foreach (var poll in mapController.GetAllPolls())
            {
                Console.WriteLine($"ProviderID: {poll.ProviderID}, AmountNQT: {poll.AmountNQT}, IsEntitled: {poll.IsEntitled}, Timeout: {poll.Timeout}");
            }
        }
    }
}
