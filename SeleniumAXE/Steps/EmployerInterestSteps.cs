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
    internal class EmployerInterestSteps : BaseClass
    {
        private EmployerInterestPage employer;

        public EmployerInterestSteps(EmployerInterestPage employer, IWebDriver driver) : base(driver)
        {
            this.employer = new EmployerInterestPage(Driver);
        }

        [Then(@"a Employer Interest Page is displayed")]
        public void ThenAEmployerInterestPageIsDisplayed()
        {
            employer
                .AssertEmployerInterestPageDisplayed();
        }


    }
}
