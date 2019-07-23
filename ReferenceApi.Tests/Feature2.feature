Feature: Actual Reference API
	In order to retrieve Reference data
	As a regular human or external system
	I want to be able to interact with the Reference API

Scenario: Retrieve all Species data
	Given the API is available
	When I perform a request to the Species endpoint
	Then the API returns a '200' status code
	And a collection of 'Species' instances is retrieved

Scenario: Retrieve a specific Species
	Given the API is available
	When I perform a request to the Species endpoint with the identifier '1'
	Then the API returns a '200' status code
	And a 'Species' instances is retrieved

Scenario: Species data retrieval outcomes
	Given the API is available
	When I request data from the Species endpoint the outcomes are as expected according to the table
		|Identifier|Result|
		|1         |200   |
		|5         |404   |