using AngleSharp.Dom;
using SeleniumAXE.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumAXE.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using SeleniumAXE.AutomationResources;

namespace SeleniumAXE.Pages
{
    internal class ApprenticeHomePage : BaseClass
    {
        public ApprenticeHomePage(IWebDriver driver) :base(driver){}

        #region Variables / Elements
        private string PageTitle => "Apprenticeships";

        public bool IsVisible => Driver.Title.Contains(PageTitle); // Title of HTML page from header
        public IWebElement acceptCookiesBtn => Driver.FindElement(By.Id("fiu-cb-button-accept"));
        public IWebElement closeCookiesBtn => Driver.FindElement(By.Id("fiu-cb-close"));
        public IWebElement hideMessageLink => Driver.FindElement(By.ClassName("fiu-banner__hide-link"));
        public IWebElement becomeAnApprenticeBtn => Driver.FindElement(By.Id("fiu-header-link-apprentices"));
        private IWebElement hireAnApprenticeBtn => Driver.FindElement(By.Id("fiu-header-link-employers"));

        #endregion

        #region Page Methods

        public void GoTo()
        {
            Driver.Navigate().GoToUrl("https://www.apprenticeships.gov.uk/");
            DismissCookieAlert();
        }

        

        public void DismissCookieAlert()
        {
            InputHelper.Click(acceptCookiesBtn, Driver);
            InputHelper.Click(closeCookiesBtn, Driver);
        }

        public void HideMessageLink()
        {
            InputHelper.Click(hideMessageLink, Driver);    
        }

        public bool ConfirmHideMessageLinkVisible()
        {
            // Need to use the FIND ELEMENTS method here as using the POM variable throws an expection
            var element = Driver.FindElements(By.ClassName("fiu-banner__hide-link")).Count;

            if (element > 0)
            {
                // Element is displayed
                return true;
            }
            else
            {
                // Element is not displayed
                return false;
            }
        }

        public BecomeAnApprenticePage NavigateToApprenticesPage()
        {
            InputHelper.Click(becomeAnApprenticeBtn, Driver);
            return new BecomeAnApprenticePage(Driver);
        }

        public HireAnApprenticePage NavigateToHireAnApprenticePage()
        {
            InputHelper.Click(hireAnApprenticeBtn, Driver);
            return new HireAnApprenticePage(Driver);
        }

        #endregion

        #region Assertions
        public void AssertPageVisible()
        {
            Assert.That(IsVisible, Is.True, $"Apprenticeships Home page was not visible. Expected=>{PageTitle}." +
                $" Actual=>{Driver.Title}");
        }

        public void AssertHideMessageLinkNotVisible()
        {
            Assert.False(ConfirmHideMessageLinkVisible(), $"The Hide Message Link is displayed");
        }

        
        #endregion

    }
}
