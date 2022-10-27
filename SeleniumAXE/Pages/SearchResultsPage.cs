using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoberSpecflow.Pages
{
    internal class SearchResultsPage : BasePage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver) { }

        private string PageTitle => "Search - My Store";

        public IWebElement productImg => Driver.FindElement(By.XPath("//a[@class='product_img_link']"));

        public bool IsVisible => Driver.Title.Contains(PageTitle);

        public bool SearchResultsVisible => productImg.Displayed;
    }
}
