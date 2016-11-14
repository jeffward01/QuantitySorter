using QuantitySorter.Business.Service;

namespace QuantitySorter.Console
{
    public class Application : IApplication
    {
        private readonly ISortService _sortService;

        public Application(ISortService sortService)
        {
            _sortService = sortService;
        }

        public void Run()
        {
            //do work
            _sortService.OutputQuantities();
        }
    }
}