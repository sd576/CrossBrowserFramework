using System;
using System.Collections.Generic;
using CrossBrowserTesting.HelperFiles;
using CrossBrowserTesting.PageObjects;
using CrossBrowserTesting.Resources;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Support.UI;

namespace CrossBrowserTesting.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        //Opens the browser and takes the User to the Home Page
        //prior to starting the test

        public void BeforeEveryTest(string browserName)
        {
            if (browserName.Equals("chrome"))
                driver = new ChromeDriver();
            else if (browserName.Equals("firefox"))
                driver = new FirefoxDriver();
            else if (browserName.Equals("opera"))
                driver = new OperaDriver();
            else if (browserName.Equals("ie"))
                driver = new InternetExplorerDriver();
            else driver = new EdgeDriver();

            driver.Manage().Cookies.DeleteAllCookies();

            HomePage homePage = new HomePage(driver);
            homePage.Open();
            driver.Manage().Window.Maximize();
        }

        public static IEnumerable<string> BrowserForTest()
        {
            String[] browsers = { "chrome", "firefox" };

            foreach (String b in browsers)
            {
                yield return b;
            }
        }

        //Closes down all the browsers after the tests have completed
        [TearDown]
        public void AfterEveryTest()
        {
            //driver.Quit();
            DisposeDriverService.FinishHim(driver);
        }

        protected void WaitForHomePage()
        {
            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible
                            (By.XPath("//*[contains(text(),'Popular')]")));
        }

        protected void WaitForSignInPage()
        {
            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible
                            (By.XPath("//*[contains(text(),'Authentication')]")));
        }

        protected void WaitForMyAccountPage()
        {
            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible
                            (By.XPath("//*[contains(text(),'My account')]")));
        }
    }
}
