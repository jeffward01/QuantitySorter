using System.Collections.Generic;

namespace QuantitySorter.Business.Service
{
    public interface IDataTrackerListService
    {
        void Add(string s);
        List<KeyValuePair<string, int>> Sort();
    }
}