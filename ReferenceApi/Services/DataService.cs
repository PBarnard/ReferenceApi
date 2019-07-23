using System.Collections.Generic;
using ReferenceApi.Models;
using ReferenceApi.Services.Interfaces;

namespace ReferenceApi.Services
{
    public class DataService : IDataService
    {
        public IEnumerable<Species> GetSpecies()
        {
            return new List<Species>
            {
                new Species { Id = "1", Name = "Cat" },
                new Species { Id = "2", Name = "Dog" },
                new Species { Id = "3", Name = "Fish" }
            };
        }

        public IEnumerable<Substance> GetSubstances()
        {
            return new List<Substance>
            {
                new Substance { Id = "1", Name = "Substance 1" },
                new Substance { Id = "2", Name = "Substance 2" },
                new Substance { Id = "3", Name = "Substance 3" }
            };
        }

        public IEnumerable<PharmaceuticalForm> GetPharmaceuticalForms()
        {
            return new List<PharmaceuticalForm>
            {
                new PharmaceuticalForm { Id = "1", Name = "Form 1" },
                new PharmaceuticalForm { Id = "2", Name = "Form 2" },
                new PharmaceuticalForm { Id = "3", Name = "Form 3" }
            };
        }

        public IEnumerable<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country { Id = "1", Name = "UK" },
                new Country { Id = "2", Name = "France" },
                new Country { Id = "3", Name = "Germany" }
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Id = "1", Name = "Product 1" },
                new Product { Id = "2", Name = "Product 2" },
                new Product { Id = "3", Name = "Product 3" }
            };
        }
    }
}
