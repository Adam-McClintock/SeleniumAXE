using SeleniumAXE.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using SeleniumAXE.AutomationResources;

namespace SeleniumAXE.Steps
{
    [Binding]
    [Scope(Feature = "Apprenticeships")]
    internal class BecomeAnApprenticeSteps : BaseClass
    {
        private BecomeAnApprenticePage becomeApp;

        public BecomeAnApprenticeSteps(BecomeAnApprenticePage becomeApp, IWebDriver driver) : base(driver)
        {
            this.becomeApp = new BecomeAnApprenticePage(Driver);
        }

        [When(@"I navigate to the Browse Apprenticeships page")]
        public void WhenINavigateToTheBrowseApprenticeshipsPage()
        {
            becomeApp.NavigateToBrowseApprenticeships();
        }

        [Then(@"a Become an apprentice page is displayed")]
        public void ThenABecomeAnApprenticePageIsDisplayed()
        {
            becomeApp.AssertBecomeApprenticePageDisplayed();
        }


    }
}
