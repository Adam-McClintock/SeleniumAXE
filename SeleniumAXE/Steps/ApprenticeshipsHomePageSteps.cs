using SeleniumAXE.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using FluentAssertions;
using AngleSharp.Dom;
using SeleniumAXE.AutomationResources;

namespace SeleniumAXE.Steps
{
    [Binding]
    [Scope(Feature = "Apprenticeships")]
    internal class ApprenticeshipsHomePageSteps : BaseClass
    {
        private ApprenticeHomePage homePage;

        public ApprenticeshipsHomePageSteps(ApprenticeHomePage homePage, IWebDriver driver) : base(driver)
        {
            this.homePage = new ApprenticeHomePage(Driver);
        }

        [Given(@"I have navigated to the Apprenticeships Home Page")]
        public void GivenIHaveNavigatedToTheApprenticeshipsHomePage()
        {
            homePage.GoTo();
        }

        [When(@"I hide the message banner")]
        public void WhenIHideTheMessageBanner()
        {
            homePage.HideMessageLink();
        }

        [When(@"I navigate to the Become An Apprentice page")]
        public void WhenINavigateToTheBecomeAnApprenticePage()
        {
            homePage.NavigateToApprenticesPage();
        }

        #region Assertions
        [Then(@"I confirm that the Apprenticeships Home Page is visible")]
        public void ThenIConfirmThatTheApprenticeshipsHomePageIsVisible()
        {
            homePage.AssertPageVisible();
        }

        [Then(@"I confirm the hideMessageLink is not present")]
        public void ThenIConfirmTheHideMessageLinkIsNotPresent()
        {
            homePage.AssertHideMessageLinkNotVisible();
        }

        #endregion

    }
}
