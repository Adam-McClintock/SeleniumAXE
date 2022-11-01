Feature: Apprenticeships

Testing GOV UK Apprenticeships Home Page

Background: 
	Given I have navigated to the Apprenticeships Home Page


@UI
Scenario: Navigate to Apprenticeships Home Page
	Then I confirm that the Apprenticeships Home Page is visible

@UI
Scenario: Hide Message Link
	Then I confirm that the Apprenticeships Home Page is visible
	When I hide the message banner
	Then I confirm the hideMessageLink is not present

@UI
Scenario: Navigate To Become An Apprentice Page
	When I navigate to the Become An Apprentice page
	Then a Become an apprentice page is displayed

@UI
Scenario: Navigate To Browse Apprenticeships Page
	When I navigate to the Become An Apprentice page
	Then a Become an apprentice page is displayed
	When I navigate to the Browse Apprenticeships page
	Then a Browse an Apprenticeship page is displayed

@UI
Scenario: Search for Apprenticeship - NI Postcode
	When I navigate to the Become An Apprentice page
	Then a Become an apprentice page is displayed
	When I navigate to the Browse Apprenticeships page
	Then a Browse an Apprenticeship page is displayed
	When I search for an apprenticeship in NI
	Then I confirm the NI Apprenticeship Heading is displayed

@UI
Scenario: Search for Apprenticeship - Scottish Postcode
	When I navigate to the Become An Apprentice page
	Then a Become an apprentice page is displayed
	When I navigate to the Browse Apprenticeships page
	Then a Browse an Apprenticeship page is displayed
	When I search for an apprenticeship in Scotland
	Then I confirm the Scottish Apprenticeship Heading is displayed

@UI
Scenario: Search for Apprenticeship - Welsh Postcode
	When I navigate to the Become An Apprentice page
	Then a Become an apprentice page is displayed
	When I navigate to the Browse Apprenticeships page
	Then a Browse an Apprenticeship page is displayed
	When I search for an apprenticeship in Wales
	Then I confirm the Welsh Apprenticeship Heading is displayed

@UI
Scenario: Search for Apprenticeship - Empty Search
	When I navigate to the Become An Apprentice page
	Then a Become an apprentice page is displayed
	When I navigate to the Browse Apprenticeships page
	Then a Browse an Apprenticeship page is displayed
	When I search for an apprenticeship with empty fields
	Then an error alert is displayed
	And the empty field validation messages are displayed

@UI
Scenario: Search for Apprenticeship - Valid
	When I navigate to the Become An Apprentice page
	Then a Become an apprentice page is displayed
	When I navigate to the Browse Apprenticeships page
	Then a Browse an Apprenticeship page is displayed
	When I search for a valid apprenticeship
	Then I confirm that results are displayed






