using System.Collections.Generic;
using ReferenceApi.Models;

namespace ReferenceApi.Tests
{
    public static class StubData
    {
        public static IEnumerable<Species> GetAllSpecies()
        {
            return new List<Species>
            {
                new Species { Id = "1", Name = "Cat" },
                new Species { Id = "2", Name = "Dog" },
                new Species { Id = "3", Name = "Fish" }
            };
        }

        public static IEnumerable<Substance> GetAllSubstances()
        {
            return new List<Substance>
            {
                new Substance { Id = "1", Name = "Substance 1" },
                new Substance { Id = "2", Name = "Substance 2" },
                new Substance { Id = "3", Name = "Substance 3" }
            };
        }

        public static IEnumerable<PharmaceuticalForm> GetAllPharmaceuticalForms()
        {
            return new List<PharmaceuticalForm>
            {
                new PharmaceuticalForm { Id = "1", Name = "Form 1" },
                new PharmaceuticalForm { Id = "2", Name = "Form 2" },
                new PharmaceuticalForm { Id = "3", Name = "Form 3" }
            };
        }

        public static IEnumerable<Country> GetAllCountries()
        {
            return new List<Country>
            {
                new Country { Id = "1", Name = "UK" },
                new Country { Id = "2", Name = "France" },
                new Country { Id = "3", Name = "Germany" }
            };
        }

        public static IEnumerable<Product> GetAllProducts()
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
