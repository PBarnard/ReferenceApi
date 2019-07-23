using System.Collections.Generic;
using ReferenceApi.Models;

namespace ReferenceApi.Services.Interfaces
{
    public interface IDataService
    {
        IEnumerable<Species> GetSpecies();
        IEnumerable<Substance> GetSubstances();
        IEnumerable<PharmaceuticalForm> GetPharmaceuticalForms();
        IEnumerable<Country> GetCountries();
        IEnumerable<Product> GetProducts();
    }
}