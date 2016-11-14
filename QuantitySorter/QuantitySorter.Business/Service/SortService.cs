using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

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
            foreach (var topping in quantites)
            {
                var toppings = JsonConvert.SerializeObject(topping.Ingredients);
                _dataTrackerList.Add(toppings);
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
                    var myKey = Regex.Unescape(JsonConvert.SerializeObject(pair.Key));
                    myKey = RemoveSpecialCharacters(myKey);
                    Console.WriteLine("{2}). {0}: {1}", myKey, pair.Value, counter + 1);
                }
                else
                {
                    break;
                }
                counter++;
            }
        }

        private static string RemoveSpecialCharacters(string str)
        {
            var myString = Regex.Replace(str, "[^0-9A-Za-z ]", " ");
            return Regex.Replace(myString, "     ", " ");
        }
    }
}