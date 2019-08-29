Feature: GetSingleResource


@mytag
@mytag
Scenario: View Resource details
	Given I have API url for get the resource
	When I send the request with send parameter
	Then resource details should display