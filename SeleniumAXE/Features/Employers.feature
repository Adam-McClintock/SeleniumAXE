Feature: Employers

A short summary of the feature

Background: 
	Given I have navigated to the Apprenticeships Home Page
	When I navigate to the Hire an Apprentice Page


	@UI
	@Employers
Scenario: Navigate to Hire an Apprentice Page
	Then a Hire an Apprentice page is displayed

	@UI
	@Employers
Scenario: Navigate to Create Advert
	When I navigate to the Create Your Advert page
	Then I am taken to the GOV UK Create Advert page

	@UI
	@Employers
Scenario: Navigate to Employer Interest Page
	When I navigate to the Employer Interest Page
	Then a Employer Interest Page is displayed





