Feature: MatchingArticleFeature
Checking if the article title matches

Background: 
	Given I am on the EPAM home page

@smoke
Scenario: I check the article title using the matching article feature
	Given I navigate to the Insights Page
	When I click on the arrow twice
	And  I click on the read more button
	And I get the current article title
	Then The article title should match the expected title
