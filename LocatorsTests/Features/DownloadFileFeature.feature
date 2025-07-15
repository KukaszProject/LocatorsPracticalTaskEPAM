Feature: Download File Feature
Downloading file from About Page

@smoke
Scenario: I download the file
	Given I am on the EPAM home page
	And I navigate to the About Page
	When I click the download button
	Then the file should be downloaded
