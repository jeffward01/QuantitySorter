using System.Collections.Generic;
using System.Linq;

namespace QuantitySorter.Business.Service
{

    public class DataTrackerListService : IDataTrackerListService
    {
        public readonly Dictionary<string, int> countingList = new Dictionary<string, int>();

        public void Add(string s)
        {
            if (!countingList.ContainsKey(s))
                countingList.Add(s, 1);
            else
                countingList[s]++;
        }

        public List<KeyValuePair<string, int>> Sort()
        {
            var myList = countingList.ToList();

            myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            return myList;
        }
    }
}