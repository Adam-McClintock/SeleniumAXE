using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
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
        public static void WhenIClickOnTheButton(IWebElement element, IWebDriver Driver)
        {
            // Using JS as I've been getting the error Element is not clickable at point
            WaitHelper.WaitForElementClickable(element, Driver);
            element.Click();
        }

        public static void javascriptClick(IWebElement element, IWebDriver Driver)
        {
            // Using JS as I've been getting the error Element is not clickable at point
            WaitHelper.WaitForElementClickable(element, Driver);
            Driver.ExecuteJavaScript("arguments[0].click()", element);
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
