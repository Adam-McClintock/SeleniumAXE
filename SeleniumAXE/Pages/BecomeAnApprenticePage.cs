using SeleniumAXE.Pages;
using OpenQA.Selenium;
using SeleniumAXE.Utilities;
using SeleniumAXE.AutomationResources;
using TechTalk.SpecFlow;

namespace SeleniumAXE.Pages
{
    internal class BecomeAnApprenticePage : BaseClass
    {
        public BecomeAnApprenticePage(IWebDriver driver) : base(driver) {}

        private string PageTitle => "Become an apprentice";

        public IWebElement browseApprenticeshipsBtn => Driver.FindElement(By.Id("fiu-app-menu-link-4"));

        public BrowseApprenticeshipsPage NavigateToBrowseApprenticeships()
        {
            InputHelper.WhenIClickOnTheButton(browseApprenticeshipsBtn, Driver);
            return new BrowseApprenticeshipsPage(Driver);
        }

        public void AssertBecomeApprenticePageDisplayed()
        {
            PageHelper.ThenAPageIsDisplayed(PageTitle, Driver);
        }

        [Then(@"I confirm the Become An Apprentice page is accessible")]
        public void ThenIConfirmTheBecomeAnApprenticePageIsAccessible()
        {
            AXEHelper.AXEReportScan("BecomeAnApprentice", Driver);
        }



    }
}