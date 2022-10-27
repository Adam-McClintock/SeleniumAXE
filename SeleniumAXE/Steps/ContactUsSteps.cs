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
    [Scope(Feature = "ContactUs")]
    internal class ContactUsSteps : BasePage
    {
        public ContactUsSteps(ContactUsPage contactUsPage, IWebDriver driver) : base(driver)
        {
            this.contactUsPage = new ContactUsPage(Driver);
        }

        private AutomationPracticeHomePage AP_HomePage => new AutomationPracticeHomePage(Driver);
        private ContactUsPage contactUsPage;

        [When(@"I navigate to the contactUsPage")]
        public void WhenINavigateToTheContactUsPage()
        {
            contactUsPage = AP_HomePage.NavigateToContactUsPage();
        }

        [Then(@"I confirm that the contactUsPage is visible")]
        public void ThenIConfirmThatTheContactUsPageIsVisible()
        {
            AssertPageVisible(contactUsPage);
        }

        [Then(@"I confirm that the contact us form is visible")]
        public void ThenIConfirmThatTheContactUsFormIsVisible()
        {
            AssertContactUsFormIsVisible(contactUsPage);
        }

        [When(@"I complete and submit the contact form")]
        public void WhenICompleteAndSubmitTheContactForm()
        {
            contactUsPage.SubmitCompletedContactForm();
        }

        [Then(@"I confirm that the contact form has been submitted")]
        public void ThenIConfirmThatTheContactFormHasBeenSubmitted()
        {
            AssertContactFormSubmitted(contactUsPage);
        }

        #region Assertions
        private void AssertPageVisible(ContactUsPage contactUsPage)
        {
            Assert.IsTrue(contactUsPage.IsVisible, "Contact Us page was not visible.");
        }

        private void AssertContactUsFormIsVisible(ContactUsPage contactUsPage)
        {
            Assert.IsTrue(contactUsPage.ContactUsFormVisible, "Contact Us form was not visible.");
        }

        private void AssertContactFormSubmitted(ContactUsPage contactUsPage)
        {
            Assert.IsTrue(contactUsPage.alertVisible, "Alert is not visible");
        }

        #endregion

        [Then(@"I confirm that the Contact Us Page is Accessible")]
        public void ThenIConfirmThatTheContactUsPageIsAccessible()
        {
            contactUsPage.AXEReportScan("Contact Us Page");
        }
    }
}
