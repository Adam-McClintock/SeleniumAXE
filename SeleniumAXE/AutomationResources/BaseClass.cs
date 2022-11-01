using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumAXE.AutomationResources
{
    [Binding]
    public class BaseClass : TechTalk.SpecFlow.Steps
    {
        // BaseClass
        protected IWebDriver Driver { get; }

        public BaseClass(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
