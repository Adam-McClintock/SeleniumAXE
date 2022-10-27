using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoberSpecflow.Pages
{
    internal class AutomationPracticeHomePage : BasePage
    {
        public AutomationPracticeHomePage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsVisible => Driver.Title.Contains(PageTitle); // Title of HTML page from header

        public IWebElement searchField => Driver.FindElement(By.Id("search_query_top"));
        public IWebElement searchButton => Driver.FindElement(By.XPath("//button[@name='submit_search']"));
        public IWebElement contactUsLink => Driver.FindElement(By.XPath("//a[@title='Contact Us']"));

        private string PageTitle => "My Store";

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Assert.IsTrue(IsVisible,
                $"Automation Practice Home page was not visible. Expected=>{PageTitle}." +
                $" Actual=>{Driver.Title}");
        }

        internal ContactUsPage NavigateToContactUsPage()
        {
            contactUsLink.Click();
            WaitForForm();
            return new ContactUsPage(Driver);
        }

        internal SearchResultsPage SearchForAProduct(string product)
        {
            searchField.SendKeys(product);
            searchButton.Submit();
            return new SearchResultsPage(Driver);

        }

    }
}
