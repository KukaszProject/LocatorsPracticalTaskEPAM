Feature: GlobalSearchFeature

Background: 
	

@smoke
Scenario Outline: I perform a global search on the EPAM home page
	Given I am on the EPAM home page
	And I navigate to the Global Search
	When I enter "<keyword>" in the search field
	And  I click the find button
	Then I should see search results related to "<keyword>"
	Examples:
	| keyword    |
	| BLOCKCHAIN  |
	| Automation |
	| Cloud      |
