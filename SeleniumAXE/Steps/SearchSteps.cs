using OctoberSpecflow.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace OctoberSpecflow.Steps
{
    [Binding]
    [Scope(Feature = "SearchFunctionalityFeature")]
    internal class SearchSteps : BasePage
    {

        private AutomationPracticeHomePage AP_HomePage => new AutomationPracticeHomePage(Driver);
        private SearchResultsPage searchResultsPage;

        public SearchSteps(SearchResultsPage searchResultsPage, IWebDriver driver) : base(driver)
        {
            this.searchResultsPage = new SearchResultsPage(Driver);
        }


        [When(@"I use the search bar to search for a ""([^""]*)""")]
        public void WhenIUseTheSearchBarToSearchForA(string product)
        {
            searchResultsPage = AP_HomePage.SearchForAProduct(product);
        }

        [Then(@"I should be taken to the Search Results page")]
        public void ThenIShouldBeTakenToTheSearchResultsPage()
        {
            AssertPageVisible(searchResultsPage);
        }

        [Then(@"products should be displayed")]
        public void ThenProductsShouldBeDisplayed()
        {
            Thread.Sleep(3000); // TEMP, ADD GLOBAL WAIT METHOD
            AssertProductsAreDisplayed(searchResultsPage, "BLOUSE");
        }


        #region Assertions
        private void AssertPageVisible(SearchResultsPage searchResultsPage)
        {
            Assert.IsTrue(searchResultsPage.IsVisible, "Search Results page was not visible.");
        }

        private void AssertProductsAreDisplayed(SearchResultsPage searchResultsPage, string product)
        {
            try
            {
                Assert.IsTrue(searchResultsPage.SearchResultsVisible, "Search Results does not contain products.");

            }
            catch (NoSuchElementException)
            {
                throw new Exception($"No search results were found for given search of '{product}'");
            }
            //Assert.IsTrue(searchResultsPage.SearchResultsVisible, "Search Results does not contain products.");
        }
        #endregion

    }
}
