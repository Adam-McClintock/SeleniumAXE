using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using SeleniumAXE.AutomationResources;
using SeleniumAXE.Utilities;
using TechTalk.SpecFlow;

namespace SeleniumAXE.Pages
{
    internal class BrowseApprenticeshipsPage : BaseClass
    {
        public BrowseApprenticeshipsPage(IWebDriver driver) : base(driver) { }

        private string PageTitle => "Browse apprenticeships before you apply";
        public IWebElement routeDropDown => Driver.FindElement(By.Id("Route"));
        public IWebElement postCodeField => Driver.FindElement(By.Id("Postcode"));
        public IWebElement searchBtn => Driver.FindElement(By.Id("search-apprenticeship"));
        public IWebElement errorSummaryAlert => Driver.FindElement(By.ClassName("govuk-error-summary"));
        public string errorAlertHeading => Driver.FindElement(By.Id("error-summary-title")).Text;
        public IWebElement routeValidationMsg => Driver.FindElement(By.XPath("*//a[@href='#Route']"));
        public IWebElement postcodeValidationMsg => Driver.FindElement(By.XPath("*//a[@href='#Postcode']"));

        public IWebElement resultsSummary => Driver.FindElement(By.Id("resultsSummary"));
        public int resultPanels => Driver.FindElements(By.ClassName("fiu-results-panel")).Count;

        public void AssertBrowseApprenticeshipDisplayed()
        {
            PageHelper.ThenAPageIsDisplayed(PageTitle, Driver);
        }

        public void SearchForApprenticeship(string routeSelection, string postcode)
        {
            InputHelper.dropDownSelector(routeDropDown, routeSelection);
            InputHelper.InputText(postCodeField, postcode);
            InputHelper.Click(searchBtn, Driver);
        }

        public void AssertHeadingDisplayed(string pageHeading)
        {
            PageHelper.ThenAPageIsDisplayed(pageHeading, Driver);
        }

        public void EmptyApprenticeshipSearch()
        {
            InputHelper.Click(searchBtn, Driver);
        }

        public void AssertErrorAlertIsDisplayed()
        {
            bool check;
            if (errorSummaryAlert.Displayed && errorAlertHeading == "There is a problem")
            {
                check = true;
            } else check = false;

            Assert.IsTrue(check, "The error alert is not displayed");
        }

        public void AssertEmptyValidationDisplayed()
        {
            bool check;
            if (routeValidationMsg.Displayed && postcodeValidationMsg.Displayed)
            {
                check = true;
            }
            else check = false;

            Assert.IsTrue(check, "The Validation Messages are not displayed");
        }

        public void AssertApprenticeshipSearchResultsDisplayed()
        {
            bool check;
            if (resultsSummary.Displayed && resultPanels > 0)
            {
                check = true;
            }
            else check = false;

            Assert.IsTrue(check, "No results are displayed");
        }
    }
}