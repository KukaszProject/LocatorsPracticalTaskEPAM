Feature: ServicesNavigationFeature

Background:
	Given I am on the EPAM home page

  @Smoke
  Scenario Outline: Navigate to <ServiceCategory> page and validate section
	Given I navigate to the Services page
    When  I navigate to the Artificial Inteligence section
    And I click on the "<ServiceCategory>" service category
	Then "<ServiceCategory>" should contain the expected text
    And  Our Related Expertise should be displayed

    Examples:
      | ServiceCategory  |
      | Generative AI    |
      | Responsible AI   |
