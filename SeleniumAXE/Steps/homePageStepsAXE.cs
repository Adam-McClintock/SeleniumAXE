using OctoberSpecflow.Pages;
using OpenQA.Selenium;
using Selenium.Axe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AXE_Pipeline.Steps.AXE
{
    [Binding]
    [Scope(Feature = "homePage")]
    internal class homePageStepsAXE : BasePage
    {
        public homePageStepsAXE(AutomationPracticeHomePage homePage, IWebDriver driver) : base(driver)
        {
            this.homePage = new AutomationPracticeHomePage(Driver);
        }

        private AutomationPracticeHomePage homePage;


        [Then(@"I confirm that the page is accessible")]
        public void ThenIConfirmThatThePageIsAccessible()
        {
            homePage.AXEReportScan("Home Page");
        }

    }
}
