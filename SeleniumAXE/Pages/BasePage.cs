using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using Selenium.Axe;

namespace OctoberSpecflow.Pages
{
    [Binding]
    public class BasePage :TechTalk.SpecFlow.Steps
    {
        protected IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        [Given(@"I have navigated to the Automation Practice Home Page")]
        public void GivenIHaveNavigatedToTheAutomationPracticeHomePage()
        {
            AutomationPracticeHomePage homePage = new AutomationPracticeHomePage(Driver);
            homePage.GoTo();
            ScenarioContext.Current.Add("driver", homePage);
        }

        public void WaitForElement(string element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath($"//*[@value='{element}']")));
        }

        public void WaitForForm()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath($"//*[@class='contact-form-box']")));
        }

        public void WaitForAlert(string alertMsg)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath($"//*[contains(text(), '{alertMsg}')]")));
        }

        public void dropDownSelector(IWebElement dropDown, string option)
        {
            var selectElement = new SelectElement(dropDown);
            selectElement.SelectByText(option);
        }

        #region AXE Accessibility

        // Scans the whole web page including all AXE rules sets and will output a JSON fail containing any
        // failures or violations along with links to deque/WCAG guidelines on how to rectify
        // Would probably favour AxeScanCurrentPage() or AxeScanSubPage() over the AxeBuilder methods
        public void AxeScanCurrentPage()
        {
            AxeResult result = Driver.Analyze();
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented);
            //Driver.CreateAxeHtmlReport(result, @"C:\AxeReport");

            Assert.True(string.IsNullOrEmpty(result.Error) && result.Violations.Length == 0, "Failures:" + resultJson);
        }

        // Another method that creats a html report
        public void AXEReportScan(string pageName)
        {
            pageName = pageName.Replace(" ", "");
            // I manually added a Logs folder in proj bin for this to work
            // It currently overwrites each file but could potentially add a timestamp here if wanted to keep all
            string reportPath = Path.Combine(Directory.GetCurrentDirectory(), $"{pageName}AxeReport_{DateTime.Now.ToString("dd-MMM-yyyy_HH-mm-ss")}.html");

            // AXE Scans current web page 
            AxeResult result = Driver.Analyze();

            // Report
            Driver.CreateAxeHtmlReport(result, reportPath);

            // Check if there were any violations, if there is then below code executed
            if (!File.ReadAllText(reportPath).Contains("Violation: 0"))
            {
                TestContext.AddTestAttachment(reportPath);
                Assert.Fail($"Failed accessibility violation(s) check, review HTML attachment for more details.");
                //Assert.True(string.IsNullOrEmpty(result.Error) && result.Violations.Length == 0, "Failures:" + resultJson);
            }
        }

        // Scans a sub-section of a page - if we are focusing on a specific DIV or iFrame etc we can input 
        // the locator into this method and AXE will scan against WCAG
        public void AxeScanSubPage()
        {
            var analyzeElementAndChildren = Driver.FindElement(By.CssSelector("WHATEVER LOCATOR IS"));
            AxeResult result = Driver.Analyze(analyzeElementAndChildren);

            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented);
            Assert.True(string.IsNullOrEmpty(result.Error) && result.Violations.Length == 0, "Failures:" + resultJson);
        }

        // LOWER LEVEL CODE USING AXE BUILDER
        // More complex rules if we care about specific WCAG tags, options, elements we want to specifically 
        // include or exclude, specific WCAG rules we want or don't want, where we want the fule output to
        // Usually dont use this unless specific reasoning e.g. don't care about a specific WCAG rule or elements
        public void AxeBuilderScanPage()
        {
            var builder = new AxeBuilder(Driver)
                .WithTags("wcag2a", "wcag2aa", "wcag21a", "wcag21aa");
            //.WithRules("color-contrast")
            //.DisableRules("heading-order");
            //.Include("#div1", "#div2")
            //.Exclude(".ignore")
            //.WithOutputFile(@"./raw-axe-results.json");

            var results = builder.Analyze();
        }

        // Another example of the Axe Builder scanning a specific element/area of web page
        public void AxeBuilderScanSubPage()
        {
            var builder = new AxeBuilder(Driver)
                .WithTags("wcag2a", "wcag2aa");

            var element = Driver.FindElement(By.Id("ELEMENT"));
            var results = builder.Analyze(element);
        }

        #endregion

    }
}
