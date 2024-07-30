﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassenTest
{
    public class Poll
    {
        public int ProviderID { get; set; }
        public long AmountNQT { get; set; }
        public bool IsEntitled { get; set; }
        public string HashValue { get; set; }
        public long ActorID { get; set; }
        public long TargetID { get; set; }
        public string MainMethod { get; set; }
        public string SubMethod { get; set; }
        public long Parameter { get; set; }
        public long Parameter2 { get; set; }
        public DateTime Timeout { get; set; }
        public int AgreedersCount { get; set; }
        public int RejectersCount { get; set; }
        public List<bool> Votes { get; set; } = new List<bool>();
    }

    public class MapController
    {
        private List<Poll> polls = new List<Poll>();
        private int currentProviderIndex = 0;
        private int currentElectionIndex = 0;

        public void ProcessMapEntries(List<MapEntry> entries)
        {

            // get poll/election ids (1004003 = ELECTIONS)
            List<MapEntry> pollEntries = entries.Where(me => me.Key1 == 1004003L).ToList();
            
            // create new polls with the ids
            pollEntries.ForEach(pe => polls.Add(new Poll() { HashValue = pe.Key1.ToString(), ProviderID = Convert.ToInt32(entries.FirstOrDefault(tmp => tmp.Key2 == pe.Value && tmp.Key1 == 1003001L).Value), AmountNQT = entries.FirstOrDefault(tmp => tmp.Key2 == pe.Value && tmp.Key1 == 1003004L).Value, Timeout = DateTimeOffset.FromUnixTimeMilliseconds(entries.FirstOrDefault(tmp => tmp.Key2 == pe.Value && tmp.Key1 == 1004004L).Value).LocalDateTime, ActorID = 0L, TargetID = 0L, AgreedersCount = 0, RejectersCount = 0, IsEntitled = false, MainMethod = "", SubMethod = "", Parameter = 0L, Parameter2 = 0L, Votes = new List<bool>() }));

            //foreach (MapEntry entry in entries)
            //{
            //    switch (entry.Key1)
            //    {
            //        case 1:
            //            HandleProviderEntry(entry); break;
            //        case 2:
            //            HandleEntitledEntry(entry); break;
            //        case 3:
            //            HandleElectionEntry(entry); break;
            //        case 4:
            //            HandleProviderIDEntry(entry); break;
            //        case 5:
            //            HandleActorIDEntry(entry); break;
            //        case 6:
            //            HandleTargetIDEntry(entry); break;
            //        case 7:
            //            HandleMainMethodEntry(entry); break;
            //        case 8:
            //            HandleSubMethodEntry(entry); break;
            //        case 9:
            //            HandleParameterEntry(entry); break;
            //        case 10:
            //            HandleParameter2OrTimeoutEntry(entry); break;
            //        case 11:
            //            HandleAgreedersEntry(entry); break;
            //        case 12:
            //            HandleRejectersEntry(entry); break;
            //        default:
            //            HandleVoteEntry(entry); break;
            //    }
            //}
        }

        //private void HandleProviderEntry(MapEntry entry)
        //{
        //    if (entry.Key2 == 0)
        //    {
        //        currentProviderIndex++;
        //    }
        //    else if (entry.Key2 == 1)
        //    {
        //        var providerID = (int)(entry.Value >> 32);
        //        var amountNQT = entry.Value & 0xFFFFFFFF;
        //        if (!polls.ContainsKey(providerID.ToString()))
        //        {
        //            polls[providerID.ToString()] = new Poll { ProviderID = providerID, AmountNQT = amountNQT };
        //        }
        //    }
        //}

        //private void HandleEntitledEntry(MapEntry entry)
        //{
        //    if (entry.Key2 == 0) return;
        //    var providerID = (int)entry.Value;
        //    if (polls.ContainsKey(providerID.ToString()))
        //    {
        //        polls[providerID.ToString()].IsEntitled = entry.Value != 0;
        //    }
        //}

        //private void HandleElectionEntry(MapEntry entry)
        //{
        //    if (entry.Key2 == 0)
        //    {
        //        currentElectionIndex++;
        //    }
        //    else if (entry.Key2 == 1)
        //    {
        //        var hashValue = entry.Value.ToString("X");
        //        if (!polls.ContainsKey(hashValue))
        //        {
        //            polls[hashValue] = new Poll { HashValue = hashValue };
        //        }
        //    }
        //}

        //private void HandleProviderIDEntry(MapEntry entry)
        //{
        //    var hashValue = entry.Key2.ToString("X");
        //    if (polls.ContainsKey(hashValue))
        //    {
        //        polls[hashValue].ProviderID = (int)entry.Value;
        //    }
        //}

        //private void HandleActorIDEntry(MapEntry entry)
        //{
        //    var hashValue = entry.Key2.ToString("X");
        //    if (polls.ContainsKey(hashValue))
        //    {
        //        polls[hashValue].ActorID = entry.Value;
        //    }
        //}

        //private void HandleTargetIDEntry(MapEntry entry)
        //{
        //    var hashValue = entry.Key2.ToString("X");
        //    if (polls.ContainsKey(hashValue))
        //    {
        //        polls[hashValue].TargetID = entry.Value;
        //    }
        //}

        //private void HandleMainMethodEntry(MapEntry entry)
        //{
        //    var hashValue = entry.Key2.ToString("X");
        //    if (polls.ContainsKey(hashValue))
        //    {
        //        polls[hashValue].MainMethod = entry.Value.ToString();
        //    }
        //}

        //private void HandleSubMethodEntry(MapEntry entry)
        //{
        //    var hashValue = entry.Key2.ToString("X");
        //    if (polls.ContainsKey(hashValue))
        //    {
        //        polls[hashValue].SubMethod = entry.Value.ToString();
        //    }
        //}

        //private void HandleParameterEntry(MapEntry entry)
        //{
        //    var hashValue = entry.Key2.ToString("X");
        //    if (polls.ContainsKey(hashValue))
        //    {
        //        polls[hashValue].Parameter = entry.Value;
        //    }
        //}

        //private void HandleParameter2OrTimeoutEntry(MapEntry entry)
        //{
        //    var hashValue = entry.Key2.ToString("X");
        //    if (polls.ContainsKey(hashValue))
        //    {
        //        if (entry.Key2 == 9)
        //        {
        //            polls[hashValue].Parameter2 = entry.Value;
        //        }
        //        else if (entry.Key2 == 10)
        //        {
        //            polls[hashValue].Timeout = DateTimeOffset.FromUnixTimeSeconds(entry.Value).DateTime;
        //        }
        //    }
        //}

        //private void HandleAgreedersEntry(MapEntry entry)
        //{
        //    var hashValue = entry.Key2.ToString("X");
        //    if (polls.ContainsKey(hashValue))
        //    {
        //        polls[hashValue].AgreedersCount = (int)entry.Value;
        //    }
        //}

        //private void HandleRejectersEntry(MapEntry entry)
        //{
        //    var hashValue = entry.Key2.ToString("X");
        //    if (polls.ContainsKey(hashValue))
        //    {
        //        polls[hashValue].RejectersCount = (int)entry.Value;
        //    }
        //}

        //private void HandleVoteEntry(MapEntry entry)
        //{
        //    var hashValue = entry.Key2.ToString("X");
        //    if (polls.ContainsKey(hashValue))
        //    {
        //        polls[hashValue].Votes.Add(entry.Value != 0);
        //    }
        //}

        public List<Poll> GetActivePolls()
        {
            var activePolls = new List<Poll>();
            foreach (var pol in polls)
            {
                if (pol.Timeout > DateTime.Now && !pol.IsEntitled)
                {
                    activePolls.Add(pol);
                }
            }
            return activePolls;
        }

        public List<Poll> GetAllPolls()
        {
            return polls;
        }


    }
}
