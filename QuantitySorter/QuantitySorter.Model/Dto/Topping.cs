using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuantitySorter.Model.Dto
{
    [DataContract]
    public class Topping
    {
        [DataMember(Name = "toppings")]
        public List<string> Ingredients { get; set; }
    }
}
