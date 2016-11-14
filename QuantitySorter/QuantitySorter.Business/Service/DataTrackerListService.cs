using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using QuantitySorter.Model.Dto;

namespace QuantitySorter.Business.Service
{

    public class DataTrackerListService : IDataTrackerListService
    {
        public readonly Dictionary<string, int> countingList = new Dictionary<string, int>();

        public void Add(string s)
        {
            var listString = JsonConvert.SerializeObject(s);
            if (!countingList.ContainsKey(listString))
                countingList.Add(listString, 1);
            else
                countingList[listString]++;
        }

        public List<KeyValuePair<string, int>> Sort()
        {
            var myList = countingList.ToList();

            myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            return myList;
        }
    }
}