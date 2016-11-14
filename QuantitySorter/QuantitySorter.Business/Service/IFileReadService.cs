using System.Collections.Generic;
using QuantitySorter.Model.Dto;

namespace QuantitySorter.Business.Service
{
    public interface IFileReadService
    {
        List<Topping> LoadJson();
    }
}