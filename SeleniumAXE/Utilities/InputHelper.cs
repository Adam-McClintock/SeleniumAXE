using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAXE.Utilities
{
    public static class InputHelper
    {
        public static void WhenIClickOnTheButton(IWebElement element)
        {
            element.Click();
        }

        public static void dropDownSelector(IWebElement dropDown, string option)
        {
            var selectElement = new SelectElement(dropDown);
            selectElement.SelectByText(option);
        }

        public static void InputText(IWebElement element, string text)
        {
            element.SendKeys(text);
        }


    }
}
