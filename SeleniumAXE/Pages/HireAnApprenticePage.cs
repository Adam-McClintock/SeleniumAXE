using OpenQA.Selenium;
using SeleniumAXE.AutomationResources;
using SeleniumAXE.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAXE.Pages
{
    internal class HireAnApprenticePage : BaseClass
    {
        public HireAnApprenticePage(IWebDriver driver) : base(driver) { }

        #region Variables / Elements
        private string PageTitle => "Hire an apprentice";
        private IWebElement createAdvertBtn => Driver.FindElement(By.Id("fiu-panel-link-fat"));
        private IWebElement registerInterestBtn => Driver.FindElement(By.Id("fiu-panel-link-reg-int-emp"));

        public bool IsVisible => Driver.Title.Contains(PageTitle); // Title of HTML page from header

        #endregion

        public GOV_CreateYourAdvertPage NavigateToCreateYourAdvert()
        {
            InputHelper.javascriptClick(createAdvertBtn, Driver);
            return new GOV_CreateYourAdvertPage(Driver);
        }

        public EmployerInterestPage NavigateToEmployerInterestForm()
        {
            InputHelper.javascriptClick(registerInterestBtn, Driver);
            return new EmployerInterestPage(Driver);
        }

        

        #region Assertions
        public void AssertPageVisible()
        {
            Assert.That(IsVisible, Is.True, $"Hire An Apprentice page was not visible. Expected=>{PageTitle}." +
                $" Actual=>{Driver.Title}");
        }

        #endregion

    }
}
