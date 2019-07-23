using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ReferenceApi.Services.Interfaces;

namespace ReferenceApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        private readonly IDataService _dataService;

        public ReferenceController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        [HttpGet]
        [Route("species")]
        public ActionResult Species()
        {
            try
            {
                var species = this._dataService.GetSpecies();

                return this.Ok(species);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("species/{id}")]
        public ActionResult SpeciesById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    return this.BadRequest("Species identifier must be provided");
                }

                var result = this._dataService.GetSpecies().SingleOrDefault(species => species.Id == id);

                if (result == null)
                {
                    return this.NotFound($"Species with Id: '{id}' not found");
                }

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("substance")]
        public ActionResult Substance()
        {
            try
            {
                var substances = this._dataService.GetSubstances();

                return this.Ok(substances);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("substance/{id}")]
        public ActionResult SubstanceById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    return this.BadRequest("Substance identifier must be provided");
                }

                var result = this._dataService.GetSubstances().SingleOrDefault(species => species.Id == id);

                if (result == null)
                {
                    return this.NotFound($"Substance with Id: '{id}' not found");
                }

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("pharmaceuticalForm")]
        public ActionResult PharmaceuticalForm()
        {
            try
            {
                var pharmaceuticalForms = this._dataService.GetPharmaceuticalForms();

                return this.Ok(pharmaceuticalForms);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("pharmaceuticalForm/{id}")]
        public ActionResult PharmaceuticalFormById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    return this.BadRequest("PharmaceuticalForm identifier must be provided");
                }

                var result = this._dataService.GetPharmaceuticalForms().SingleOrDefault(pharmaceuticalForm => pharmaceuticalForm.Id == id);

                if (result == null)
                {
                    return this.NotFound($"PharmaceuticalForm with Id: '{id}' not found");
                }

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("countries")]
        public ActionResult Countries()
        {
            try
            {
                var countries = this._dataService.GetCountries();

                return this.Ok(countries);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("product")]
        public ActionResult Product()
        {
            try
            {
                var products = this._dataService.GetProducts();

                return this.Ok(products);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("product/{id}")]
        public ActionResult ProductById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    return this.BadRequest("Product identifier must be provided");
                }

                var result = this._dataService.GetProducts().SingleOrDefault(product => product.Id == id);

                if (result == null)
                {
                    return this.NotFound($"Product with Id: '{id}' not found");
                }

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
    }
}
