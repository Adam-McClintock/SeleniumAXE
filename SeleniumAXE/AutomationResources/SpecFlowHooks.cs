using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Reflection;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using System.Drawing;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using SeleniumAXE;

namespace SeleniumAXE.AutomationResources
{
    [Binding]
    public class SpecFlowHooks
    {
        private readonly IObjectContainer container;

        public SpecFlowHooks(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            IWebDriver Driver;
            string browser = Environment.GetEnvironmentVariable("browser", EnvironmentVariableTarget.Process);

            //Including the below to allow us to run a test locally as the code above is looking for
            // a browser variable from the Azure Pipeline
            if(browser == null)
            {
                browser = "firefox";
            }

            Console.WriteLine("Chosen browser is : " + browser.ToLower());
            switch (browser.ToLower())
            {
                case "chrome":
                    Driver = new ChromeDriver(GetChromeOptions());
                    {
                        Console.WriteLine("Clear cache?: " + Settings.Default.ClearCache);
                        Driver.Manage().Window.Maximize();
                        if (Settings.Default.ClearCache)
                        {
                            ClearChromeCache(Driver);
                        }                       
                    };
                    break;
                case "firefox":
                    Driver = GetFireFoxDriver();
                    break;
                case "edge":
                    Driver = GetEdgeDriver();
                    break;
                default:
                    Driver = new ChromeDriver(GetChromeOptions());
                    {
                        Console.WriteLine("Clear cache?: " + Settings.Default.ClearCache);
                        Driver.Manage().Window.Maximize();
                        if (Settings.Default.ClearCache)
                        {
                            ClearChromeCache(Driver);
                        }
                    };
                    break;
            }
            container.RegisterInstanceAs(Driver);
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            IWebDriver Driver = container.Resolve<IWebDriver>();

            Driver.Close();
            Driver.Dispose();
        }

        #region Chrome Driver
        public ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();

            // use headless chrome
            if (Settings.Default.Headless)
            {
                options.AddArguments(new List<string>()
                    {
                        "--headless",
                        "--no-first-run",
                        "--window-size=1280,1920",
                        "--start-maximized",
                        "--incognito"
                    });
            }
            return options;
        }

        public void ClearChromeCache(IWebDriver Driver)
        {
            Console.WriteLine("Attempting to clear chrome browser cache");
            string cacheMessage = "";

            Driver.Navigate().GoToUrl("chrome://settings/clearBrowserData");
            Thread.Sleep(2000);

            if (!Driver.Title.Equals("Settings"))
            {
                cacheMessage = "Unable to clear cache using this method!";
            }
            else
            {
                //Let's try to interact with the settings page
                Actions a = new Actions(Driver);
                a.SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Enter)
                    .Build()
                    .Perform();

                //Driver.TakeScreenshot().SaveAsFile(Settings.Default.ScreenshotPath + "\\" + DateTime.Now.ToString("yyyymmddhhmmssfff") + ".jpg", ScreenshotImageFormat.Jpeg);

                for (int i = 0; i < Settings.Default.DelayCycles; i++)
                {
                    if (Driver.Url.Equals("chrome://settings/"))
                    {
                        cacheMessage = "Successfully cleared cache after " + (i * Settings.Default.Delays) / 1000 + " seconds!";
                        break;
                    }
                    Thread.Sleep(Settings.Default.Delays);
                }
            }
        }

        #endregion

        #region Firefox Driver
        public static FirefoxOptions GetFireFoxOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("print.always_print_silent", true);
            options.AddArgument("--headless");
            options.AddArguments("-width=1920");
            options.AddArguments("-height=1080");
            // May need to add specific width and heigh here when running in headless.
            // Sometimes can run into issues where elements do not fit into viewpoint
            return options;
        }

        private static FirefoxDriverService GetFireFoxDriverService()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            return service;
        }

        private static FirefoxDriver GetFireFoxDriver()
        {
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            firefoxProfile.SetPreference("print.always_print_silent", true);
            FirefoxDriver driver = new FirefoxDriver(GetFireFoxDriverService(), GetFireFoxOptions());
            return driver;
        }
        #endregion

        #region Edge Driver
        private static EdgeOptions GetEdgeOptions()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("InPrivate");
            options.AddArgument("start-maximized");
            options.AddArgument("headless");
            options.BinaryLocation = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
            return options;
        }

        private static EdgeDriver GetEdgeDriver()
        {
            EdgeDriver driver = new EdgeDriver(GetEdgeDriverService(), GetEdgeOptions());
            return driver;
        }

        private static EdgeDriverService GetEdgeDriverService()
        {
            EdgeDriverService service = EdgeDriverService.CreateDefaultService();
            service.UseVerboseLogging = true;
            //service.UseSpecCompliantProtocol = true;
            return service;
        }
        #endregion


    }
}
