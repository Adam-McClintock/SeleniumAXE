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
    internal class GOV_CreateYourAdvertPage : BaseClass
    {
        public GOV_CreateYourAdvertPage(IWebDriver driver) : base(driver) { }

        private string PageTitle => "Creating an apprenticeship advert as an employer";

        public void AssertCreateAdvertPageDisplayed()
        {
            PageHelper.ThenAPageIsDisplayed(PageTitle, Driver);
        }
    }
}
