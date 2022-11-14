using OpenQA.Selenium;
using SeleniumAXE.AutomationResources;
using SeleniumAXE.Utilities;

namespace SeleniumAXE.Pages
{
    public class EmployerInterestPage : BaseClass
    {
        public EmployerInterestPage(IWebDriver driver) : base(driver) { }

        private string PageTitle => "Sign up to stay connected";

        public void AssertEmployerInterestPageDisplayed()
        {
            PageHelper.ThenAPageIsDisplayed(PageTitle, Driver);
        }
    }
}