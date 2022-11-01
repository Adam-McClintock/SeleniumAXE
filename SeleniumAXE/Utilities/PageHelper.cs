using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAXE.Utilities
{
    public static class PageHelper
    {

        public static void ThenAPageIsDisplayed(string heading, IWebDriver Driver)
        {
            Boolean headerFound = false;
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    List<String> headers = ((IEnumerable<IWebElement>)((ISearchContext)Driver).FindElements(By.CssSelector("h1, h2, h3, h5, h6"))).Select<IWebElement, string>((Func<IWebElement, string>)(h => h.Text)).ToList();
                    if (headers.Contains(heading))
                    {
                        headerFound = true;
                        break;
                    }
                }
                catch (StaleElementReferenceException)
                {

                }
                Thread.Sleep(Settings.Default.Delays);
            }
            //if (!headerFound) throw new Exception(heading + " page is not displayed. " + driver.Title + " is page title for " + driver.Url + ". Contents is: " + driver.FindElement(By.CssSelector("body")).GetAttribute("innerHTML"));
            if (!headerFound) throw new Exception(heading + " page is not displayed. Page displayed has title of " + Driver.Title + " and URL of " + Driver.Url + ".");
        }

        public static void ConfirmTextDisplayed(string text, IWebElement Driver)
        {
            String bodyText = Driver.FindElement(By.TagName("body")).Text;
            Assert.IsTrue(bodyText.Contains(text));
        }

        public static void ThenIConfirmThatTheMessageIsNotDisplayed(string text, IWebDriver Driver)
        {
            String bodyText = Driver.FindElement(By.TagName("body")).Text;
            Assert.IsTrue(bodyText.Contains(text), $"Message: {text} is not visible");
        }

        public static void ThenIConfirmThatTheMessageIsNotVisible(string text, IWebDriver Driver)
        {
            String bodyText = Driver.FindElement(By.TagName("body")).Text;
            Assert.IsFalse(bodyText.Contains(text), $"Message: {text} is visible");
        }
    }
}
