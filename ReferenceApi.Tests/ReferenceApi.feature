Feature: Reference API
	In order to retrieve Reference data
	As a regular human or external system
	I want to be able to interact with the Reference API

Scenario: Retrieve all Species data
	Given the API is available
	When I perform a request to the Species endpoint
	Then the API returns a 200 status code
	And a collection of 'Species' instances is retrieved
	
Scenario: Retrieve all PharmaceuticalForm data
	Given the API is available
	When I perform a request to the PharmaceuticalForm endpoint
	Then the API returns a 200 status code
	And a collection of 'PharmaceuticalForm' instances is retrieved

Scenario: Retrieve all Country data
	Given the API is available
	When I perform a request to the Country endpoint
	Then the API returns a 200 status code
	And a collection of 'Country' instances is retrieved
	

Scenario: Retrieve all Product data
	Given the API is available
	When I perform a request to the Product endpoint
	Then the API returns a 200 status code
	And a collection of 'Product' instances is retrieved
	

Scenario: Retrieve all Substance data
	Given the API is available
	When I perform a request to the Substance endpoint
	Then the API returns a 200 status code
	And a collection of 'Substance' instances is retrieved

Scenario: Retrieve a specific Species
	Given the API is available
	When I perform a request to the Species endpoint with the identifier '1'
	Then the API returns a 200 status code
	And a 'Species' instance with identifier '1' is retrieved

Scenario: Retrieve a specific PharmaceuticalForm
	Given the API is available
	When I perform a request to the PharmaceuticalForm endpoint with the identifier '1'
	Then the API returns a 200 status code
	And a 'PharmaceuticalForm' instance with identifier '1' is retrieved

Scenario: Retrieve a specific Product
	Given the API is available
	When I perform a request to the Product endpoint with the identifier '1'
	Then the API returns a 200 status code
	And a 'Product' instance with identifier '1' is retrieved

Scenario: Retrieve a specific Substance
	Given the API is available
	When I perform a request to the Substance endpoint with the identifier '1'
	Then the API returns a 200 status code
	And a 'Substance' instance with identifier '1' is retrieved

Scenario: Species data retrieval outcomes
	Given the API is available
	When I request data from the Species endpoint the outcomes are as expected according to the table
		|Identifier|DataError|Result|
		|1         |false    |200   |
		|	       |false    |400   |
		|5         |false    |404   |
		|1         |true     |500   |

Scenario: PharmaceuticalForm data retrieval outcomes
	Given the API is available
	When I request data from the PharmaceuticalForm endpoint the outcomes are as expected according to the table
		|Identifier|DataError|Result|
		|1         |false    |200   |
		|	       |false    |400   |
		|5         |false    |404   |
		|1         |true     |500   |

Scenario: Product data retrieval outcomes
	Given the API is available
	When I request data from the Product endpoint the outcomes are as expected according to the table
		|Identifier|DataError|Result|
		|1         |false    |200   |
		|	       |false    |400   |
		|5         |false    |404   |
		|1         |true     |500   |

Scenario: Substance data retrieval outcomes
	Given the API is available
	When I request data from the Substance endpoint the outcomes are as expected according to the table
		|Identifier|DataError|Result|
		|1         |false    |200   |
		|	       |false    |400   |
		|5         |false    |404   |
		|1         |true     |500   |