Feature: SearchFunctionalityFeature
As a user I should be able to search for a product from the Automation Practice home page 
and be taken to a page containing product results

Scenario: Search for a valid product
	Given I have navigated to the Automation Practice Home Page
	When I use the search bar to search for a "Blouse"
	Then I should be taken to the Search Results page
	And products should be displayed
