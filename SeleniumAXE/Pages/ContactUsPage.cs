using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoberSpecflow.Pages
{
    internal class ContactUsPage : BasePage
    {
        // Test Comment
        //One More Test
        public ContactUsPage(IWebDriver driver) : base(driver) { }

        private string PageTitle => "Contact us - My Store";
        public IWebElement contactForm => Driver.FindElement(By.XPath("//form[@class='contact-form-box']"));
        public IWebElement subjectHeadingDropDown => Driver.FindElement(By.Id("id_contact"));
        public IWebElement emailField => Driver.FindElement(By.Id("email"));
        public IWebElement orderRefField => Driver.FindElement(By.Id("id_order"));
        public IWebElement msgBox => Driver.FindElement(By.Id("message"));
        public IWebElement sendBtn => Driver.FindElement(By.XPath("//button[@id='submitMessage']"));
        public IWebElement successAlert => Driver.FindElement(By.XPath("//p[contains(text(), 'Your message has been successfully sent to our team.')]"));

        public bool IsVisible => Driver.Title.Contains(PageTitle);

        public bool ContactUsFormVisible
        {
            get
            {
                try
                {
                    WaitForForm();
                    return contactForm.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        public bool alertVisible
        {
            get
            {
                try
                {
                    return successAlert.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }

        internal void SubmitCompletedContactForm()
        {
            Thread.Sleep(2000); // temporary addition
            dropDownSelector(subjectHeadingDropDown, "Customer service");
            emailField.SendKeys("test@test.com");
            orderRefField.SendKeys("12345");
            msgBox.SendKeys("Please confirm my expected delivery date");
            sendBtn.Submit();
            WaitForAlert(successAlert.Text);
        }
    }
}
