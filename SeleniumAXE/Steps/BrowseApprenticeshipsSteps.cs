using OpenQA.Selenium;
using SeleniumAXE.AutomationResources;
using SeleniumAXE.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumAXE.Steps
{
    [Binding]
    [Scope(Feature = "Apprenticeships")]
    internal class BrowseApprenticeshipsSteps : BaseClass
    {
        private BrowseApprenticeshipsPage browseApp;

        public BrowseApprenticeshipsSteps(BrowseApprenticeshipsPage browseApp, IWebDriver driver) : base(driver)
        {
            this.browseApp = new BrowseApprenticeshipsPage(Driver);
        }

        [Then(@"a Browse an Apprenticeship page is displayed")]
        public void ThenABrowseAnApprenticeshipPageIsDisplayed()
        {
            browseApp.AssertBrowseApprenticeshipDisplayed();
        }

        [When(@"I search for an apprenticeship in NI")]
        public void WhenISearchForAnApprenticeshipInNI()
        {
            browseApp.SearchForApprenticeship("Digital", "BT48 8DZ");
        }

        [Then(@"I confirm the NI Apprenticeship Heading is displayed")]
        public void ThenIConfirmTheNIApprenticeshipHeadingIsDisplayed()
        {
            browseApp.AssertHeadingDisplayed("Looking for apprenticeships in Northern Ireland?");
        }

        [When(@"I search for an apprenticeship in Scotland")]
        public void WhenISearchForAnApprenticeshipInScotland()
        {
            browseApp.SearchForApprenticeship("Digital", "G22 5EQ");
        }

        [Then(@"I confirm the Scottish Apprenticeship Heading is displayed")]
        public void ThenIConfirmTheScottishApprenticeshipHeadingIsDisplayed()
        {
            browseApp.AssertHeadingDisplayed("Looking for apprenticeships in Scotland?");
        }

        [When(@"I search for an apprenticeship in Wales")]
        public void WhenISearchForAnApprenticeshipInWales()
        {
            browseApp.SearchForApprenticeship("Digital", "CF10 5ET");
        }

        [Then(@"I confirm the Welsh Apprenticeship Heading is displayed")]
        public void ThenIConfirmTheWelshApprenticeshipHeadingIsDisplayed()
        {
            browseApp.AssertHeadingDisplayed("Looking for apprenticeships in Wales?");
        }

        [When(@"I search for an apprenticeship with empty fields")]
        public void WhenISearchForAnApprenticeshipWithEmptyFields()
        {
            browseApp.EmptyApprenticeshipSearch();
        }

        [Then(@"an error alert is displayed")]
        public void ThenAnErrorAlertIsDisplayed()
        {
            browseApp.AssertErrorAlertIsDisplayed();
        }

        [Then(@"the empty field validation messages are displayed")]
        public void ThenTheEmptyFieldValidationMessagesAreDisplayed()
        {
            browseApp.AssertEmptyValidationDisplayed();
        }

        [When(@"I search for a valid apprenticeship")]
        public void WhenISearchForAValidApprenticeship()
        {
            browseApp.SearchForApprenticeship("Digital", "N21 3WL");
        }

        [Then(@"I confirm that results are displayed")]
        public void ThenIConfirmThatResultsAreDisplayed()
        {
            browseApp.AssertApprenticeshipSearchResultsDisplayed();
        }








    }
}
