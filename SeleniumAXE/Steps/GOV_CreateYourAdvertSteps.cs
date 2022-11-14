using OpenQA.Selenium;
using SeleniumAXE.AutomationResources;
using SeleniumAXE.Pages;
using SeleniumAXE.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumAXE.Steps
{
    internal class GOV_CreateYourAdvertSteps : BaseClass
    {
        private GOV_CreateYourAdvertPage createAdvPage;

        public GOV_CreateYourAdvertSteps(GOV_CreateYourAdvertPage createAdvPage, IWebDriver driver) : base(driver)
        {
            this.createAdvPage = new GOV_CreateYourAdvertPage(Driver);
        }

        [Then(@"I am taken to the GOV UK Create Advert page")]
        public void ThenIAmTakenToTheGOVUKCreateAdvertPage()
        {
            createAdvPage.AssertCreateAdvertPageDisplayed();
        }




    }
}
