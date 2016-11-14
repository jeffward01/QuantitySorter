using Newtonsoft.Json;
using QuantitySorter.Model.Dto;
using System.Collections.Generic;
using System.IO;

namespace QuantitySorter.Business.Service
{
    public class FileReadService : IFileReadService
    {
        public List<Topping> LoadJson()
        {
            using (var r = new StreamReader("pizzas.json"))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Topping>>(json);
            }
        }
    }
}