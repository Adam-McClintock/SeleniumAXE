Feature: ContactUs
As a user I should be able to contact the company using a contact form
where I can enter details about my issue

Scenario: Navigate to customer service contact form
	Given I have navigated to the Automation Practice Home Page
	When I navigate to the contactUsPage
	Then I confirm that the contactUsPage is visible

Scenario: Validate Customer Contact Form is Visible
	Given I have navigated to the Automation Practice Home Page
	When I navigate to the contactUsPage
	Then I confirm that the contact us form is visible

Scenario: Validate that user is abe to submit completed contact form
	Given I have navigated to the Automation Practice Home Page
	When I navigate to the contactUsPage
	And I complete and submit the contact form
	Then I confirm that the contact form has been submitted

@AXE
Scenario: Contact Us Accessibility Scan
	Given I have navigated to the Automation Practice Home Page
	When I navigate to the contactUsPage
	Then I confirm that the contactUsPage is visible
	And I confirm that the Contact Us Page is Accessible

