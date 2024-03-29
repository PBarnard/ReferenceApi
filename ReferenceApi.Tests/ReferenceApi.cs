﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Gherkin.Ast;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReferenceApi.Controllers;
using ReferenceApi.Models;
using ReferenceApi.Services.Interfaces;
using Xunit;
using Xunit.Gherkin.Quick;

namespace ReferenceApi.Tests
{
    public sealed class ReferenceApi : Xunit.Gherkin.Quick.Feature
    {
        private ReferenceController _controller;
        private Mock<IDataService> _dataService;
        private ActionResult _controllerResponse;
        
        [Given("the API is available")]
        public void ApiIsAvailable()
        {
            this._dataService = new Mock<IDataService>(MockBehavior.Strict);

            this._controller = new ReferenceController(this._dataService.Object);

            this._controllerResponse = null;
        }

        [When(@"I perform a request to the Species endpoint")]
        public void PerformRequestToTheSpeciesEndpoint()
        {
            this.SetupAndAssertControllerAllRecords(
                () => this._controller.Species(), 
                dataService => dataService.GetSpecies(), 
                StubData.GetAllSpecies());
        }

        [When(@"I perform a request to the PharmaceuticalForm endpoint")]
        public void PerformRequestToThePharmaceuticalFormEndpoint()
        {
            this.SetupAndAssertControllerAllRecords(
                () => this._controller.PharmaceuticalForm(), 
                dataService => dataService.GetPharmaceuticalForms(), 
                StubData.GetAllPharmaceuticalForms());
        }

        [When(@"I perform a request to the Country endpoint")]
        public void PerformRequestToTheCountryEndpoint()
        {
            this.SetupAndAssertControllerAllRecords(
                () => this._controller.Countries(), 
                dataService => dataService.GetCountries(), 
                StubData.GetAllCountries());
        }

        [When(@"I perform a request to the Product endpoint")]
        public void PerformRequestToTheProductEndpoint()
        {
            this.SetupAndAssertControllerAllRecords(
                () => this._controller.Product(), 
                dataService => dataService.GetProducts(), 
                StubData.GetAllProducts());
        }

        [When(@"I perform a request to the Substance endpoint")]
        public void PerformRequestToTheSubstanceEndpoint()
        {
            this.SetupAndAssertControllerAllRecords(
                () => this._controller.Substance(), 
                dataService => dataService.GetSubstances(), 
                StubData.GetAllSubstances());
        }

        [When(@"I perform a request to the Species endpoint with the identifier '(.*)'")]
        public void PerformRequestToTheSpeciesEndpointWithIdentifier(string identifier)
        {
            this.SetupAndAssertControllerSingleRecord(
                identifier, 
                id => this._controller.SpeciesById(id), 
                dataService => dataService.GetSpecies(), 
                StubData.GetAllSpecies());
        }

        [When(@"I perform a request to the PharmaceuticalForm endpoint with the identifier '(.*)'")]
        public void PerformRequestToThePharmaceuticalFormEndpointWithIdentifier(string identifier)
        {
            this.SetupAndAssertControllerSingleRecord(
                identifier,
                id => this._controller.PharmaceuticalFormById(id),
                dataService => dataService.GetPharmaceuticalForms(),
                StubData.GetAllPharmaceuticalForms());
        }

        [When(@"I perform a request to the Product endpoint with the identifier '(.*)'")]
        public void PerformRequestToTheProductEndpointWithIdentifier(string identifier)
        {
            this.SetupAndAssertControllerSingleRecord(
                identifier,
                id => this._controller.ProductById(id),
                dataService => dataService.GetProducts(),
                StubData.GetAllProducts());
        }

        [When(@"I perform a request to the Substance endpoint with the identifier '(.*)'")]
        public void PerformRequestToTheSubstanceEndpointWithIdentifier(string identifier)
        {
            this.SetupAndAssertControllerSingleRecord(
                identifier,
                id => this._controller.SubstanceById(id),
                dataService => dataService.GetSubstances(),
                StubData.GetAllSubstances());
        }

        [When(@"I request data from the Species endpoint the outcomes are as expected according to the table")]
        public void RequestSpeciesDataFromTheApiUsingTable(DataTable dataTable)
        {
            foreach (var row in dataTable.Rows.Skip(1))
            {
                var identifier = row.Cells.ElementAt(0).Value;

                if (bool.Parse(row.Cells.ElementAt(1).Value))
                {
                    this._dataService.Setup(x => x.GetSpecies()).Throws(new ApplicationException("Something went wrong retrieving Species data"));
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(identifier))
                    {
                        this._dataService.Setup(x => x.GetSpecies()).Returns(StubData.GetAllSpecies);
                    }
                }

                this._controllerResponse = this._controller.SpeciesById(identifier);

                Assert.NotNull(this._controllerResponse);

                var result = this._controllerResponse as ObjectResult;

                Assert.NotNull(result);
                Assert.True(result.StatusCode == int.Parse(row.Cells.ElementAt(2).Value));
                this._dataService.VerifyAll();
            }
        }

        [When(@"I request data from the PharmaceuticalForm endpoint the outcomes are as expected according to the table")]
        public void RequestPharmaceuticalFormDataFromTheApiUsingTable(DataTable dataTable)
        {
            foreach (var row in dataTable.Rows.Skip(1))
            {
                var identifier = row.Cells.ElementAt(0).Value;

                if (bool.Parse(row.Cells.ElementAt(1).Value))
                {
                    this._dataService.Setup(x => x.GetPharmaceuticalForms()).Throws(new ApplicationException("Something went wrong retrieving PharmaceuticalForm data"));
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(identifier))
                    {
                        this._dataService.Setup(x => x.GetPharmaceuticalForms()).Returns(StubData.GetAllPharmaceuticalForms);
                    }
                }

                this._controllerResponse = this._controller.PharmaceuticalFormById(identifier);

                Assert.NotNull(this._controllerResponse);

                var result = this._controllerResponse as ObjectResult;

                Assert.NotNull(result);
                Assert.True(result.StatusCode == int.Parse(row.Cells.ElementAt(2).Value));
                this._dataService.VerifyAll();
            }
        }

        [When(@"I request data from the Product endpoint the outcomes are as expected according to the table")]
        public void RequestProductDataFromTheApiUsingTable(DataTable dataTable)
        {
            foreach (var row in dataTable.Rows.Skip(1))
            {
                var identifier = row.Cells.ElementAt(0).Value;

                if (bool.Parse(row.Cells.ElementAt(1).Value))
                {
                    this._dataService.Setup(x => x.GetProducts()).Throws(new ApplicationException("Something went wrong retrieving Product data"));
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(identifier))
                    {
                        this._dataService.Setup(x => x.GetProducts()).Returns(StubData.GetAllProducts);
                    }
                }

                this._controllerResponse = this._controller.ProductById(identifier);

                Assert.NotNull(this._controllerResponse);

                var result = this._controllerResponse as ObjectResult;

                Assert.NotNull(result);
                Assert.True(result.StatusCode == int.Parse(row.Cells.ElementAt(2).Value));
                this._dataService.VerifyAll();
            }
        }

        [When(@"I request data from the Substance endpoint the outcomes are as expected according to the table")]
        public void RequestSubstanceDataFromTheApiUsingTable(DataTable dataTable)
        {
            foreach (var row in dataTable.Rows.Skip(1))
            {
                var identifier = row.Cells.ElementAt(0).Value;

                if (bool.Parse(row.Cells.ElementAt(1).Value))
                {
                    this._dataService.Setup(x => x.GetSubstances()).Throws(new ApplicationException("Something went wrong retrieving Substance data"));
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(identifier))
                    {
                        this._dataService.Setup(x => x.GetSubstances()).Returns(StubData.GetAllSubstances);
                    }
                }

                this._controllerResponse = this._controller.SubstanceById(identifier);

                Assert.NotNull(this._controllerResponse);

                var result = this._controllerResponse as ObjectResult;

                Assert.NotNull(result);
                Assert.True(result.StatusCode == int.Parse(row.Cells.ElementAt(2).Value));
                this._dataService.VerifyAll();
            }
        }

        [Then(@"the API returns a (\d+) status code")]
        public void ApiReturnsStatusCode(int statusCode)
        {
            var result = this._controllerResponse as ObjectResult;

            Assert.NotNull(result);
            Assert.True(result.StatusCode == statusCode);
        }

        [And(@"an error message is included")]
        public void AnErrorMessageIsIncluded()
        {
            var result = this._controllerResponse as ObjectResult;

            Assert.NotNull(result);
            Assert.True(!string.IsNullOrWhiteSpace(result.Value.ToString()));
        }

        [And(@"a collection of '(.+)' instances is retrieved")]
        public void ACollectionOfSpeciesObjectsIsReturned(string instanceType)
        {
            var modelType = Type.GetType($"ReferenceApi.Models.{instanceType}, ReferenceApi");

            Assert.True(this._controllerResponse is ObjectResult);

            var result = (ObjectResult) this._controllerResponse;

            Assert.True(result.Value is IEnumerable<BaseEntity>);

            var data = ((IEnumerable<BaseEntity>) result.Value).ToList();

            Assert.True(data.Count() == 3);
            Assert.True(data.All(item => item.GetType().FullName == modelType.FullName));
        }

        [And(@"a '(.+)' instance with identifier '(.+)' is retrieved")]
        public void SpeciesItemRetrieved(string instanceType, string identifier)
        {
            var modelType = Type.GetType($"ReferenceApi.Models.{instanceType}, ReferenceApi");

            Assert.True(this._controllerResponse is ObjectResult);

            var result = (ObjectResult) this._controllerResponse;

            Assert.True(result.Value is BaseEntity);

            var data = (BaseEntity) result.Value;

            Assert.True(data.Id == identifier);
            Assert.True(data.GetType().FullName == modelType.FullName);
        }

        private void SetupAndAssertControllerAllRecords<T>(
            Func<ActionResult> controllerAction,
            Expression<Func<IDataService, IEnumerable<T>>> serviceFunction,
            IEnumerable<T> serviceOutput)
        {
            this._dataService.Setup(serviceFunction).Returns(serviceOutput);

            this._controllerResponse = controllerAction();

            Assert.NotNull(this._controllerResponse);
            this._dataService.VerifyAll();
        }

        private void SetupAndAssertControllerSingleRecord<T>(
            string identifier,
            Func<string, ActionResult> controllerAction,
            Expression<Func<IDataService, IEnumerable<T>>> serviceFunction,
            IEnumerable<T> serviceOutput)
        {
            if (!string.IsNullOrWhiteSpace(identifier))
            {
                this._dataService.Setup(serviceFunction).Returns(serviceOutput);
            }

            this._controllerResponse = controllerAction(identifier);

            Assert.NotNull(this._controllerResponse);
            this._dataService.VerifyAll();
        }
    }
}
