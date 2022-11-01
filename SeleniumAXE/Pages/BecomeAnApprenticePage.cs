using SeleniumAXE.Pages;
using OpenQA.Selenium;
using SeleniumAXE.Utilities;
using SeleniumAXE.AutomationResources;

namespace SeleniumAXE.Pages
{
    internal class BecomeAnApprenticePage : BaseClass
    {
        public BecomeAnApprenticePage(IWebDriver driver) : base(driver) {}

        private string PageTitle => "Become an apprentice";

        public IWebElement browseApprenticeshipsBtn => Driver.FindElement(By.Id("fiu-panel-link-faa"));

        public BrowseApprenticeshipsPage NavigateToBrowseApprenticeships()
        {
            InputHelper.WhenIClickOnTheButton(browseApprenticeshipsBtn);
            return new BrowseApprenticeshipsPage(Driver);
        }

        public void AssertBecomeApprenticePageDisplayed()
        {
            PageHelper.ThenAPageIsDisplayed(PageTitle, Driver);
        }


    }
}