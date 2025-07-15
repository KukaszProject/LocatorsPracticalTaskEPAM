Feature: JobSearchFeature
Validating job search
A short summary of the feature

Background: 
	Given I am on the EPAM home page

@smoke
Scenario Outline: I search for a job using the job search feature
	Given I navigate to the Careers Page
	When I select remote work option
	And I enter "<keyword>" in the job search field
	And  I select All Locations from location dropdown
	And I click the search button
	And I sort by date
	And I open latest job offer
	Then I should see job listings related to "<keyword>"
	Examples:
	| keyword |
	| .NET	|
	| Java  |
