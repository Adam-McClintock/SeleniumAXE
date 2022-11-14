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
    internal class HireAnApprenticeSteps : BaseClass
    {
        private HireAnApprenticePage hireApp;

        public HireAnApprenticeSteps(HireAnApprenticePage hireApp, IWebDriver driver) : base(driver)
        {
            this.hireApp = new HireAnApprenticePage(Driver);
        }

        [When(@"I navigate to the Create Your Advert page")]
        public void WhenINavigateToTheCreateYourAdvertPage()
        {
            hireApp
                .NavigateToCreateYourAdvert();
        }

        [When(@"I navigate to the Employer Interest Page")]
        public void WhenINavigateToTheEmployerInterestPage()
        {
            hireApp
                .NavigateToEmployerInterestForm();
        }



        [Then(@"a Hire an Apprentice page is displayed")]
        public void ThenAHireAnApprenticePageIsDisplayed()
        {
            hireApp
                .AssertPageVisible();
        }


    }
}
