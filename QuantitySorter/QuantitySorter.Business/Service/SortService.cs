using System;

namespace QuantitySorter.Business.Service
{
    public class SortService : ISortService
    {
        private readonly IFileReadService _fileReadService;
        private readonly IDataTrackerListService _dataTrackerList;

        public SortService(IFileReadService fileReadService, IDataTrackerListService dataTrackerListService)
        {
            _fileReadService = fileReadService;
            _dataTrackerList = dataTrackerListService;
        }

        public void OutputQuantities()
        {
            //print highest 20 quantities
            Print(FillDataList());

            Console.ReadLine();
        }

        private IDataTrackerListService FillDataList()
        {
            var quantites = _fileReadService.LoadJson();

            //Fill list
            foreach (var amount in quantites)
            {
                foreach (var ingredient in amount.Ingredients)
                {
                    _dataTrackerList.Add(ingredient);
                }
            }
            return _dataTrackerList;
        }

        private static void Print(IDataTrackerListService dictionary)
        {
            var myList = dictionary.Sort();

            var counter = 0;

            foreach (var pair in myList)
            {
                if (counter < 20)
                {
                    Console.WriteLine("{2}). {0}: {1}", pair.Key, pair.Value, counter + 1);
                }
                else
                {
                    break;
                }
                counter++;
            }
        }
    }
}