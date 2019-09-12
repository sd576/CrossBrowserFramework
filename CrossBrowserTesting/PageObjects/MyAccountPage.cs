using OpenQA.Selenium;

namespace CrossBrowserTesting.PageObjects
{
    class MyAccountPage
    {
        public MyAccountPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        //Page Title = 'My account - My Store'
        public string PageTitle => Driver.Title;

        //Page Heading = 'My account'
        public IWebElement PageHeading => Driver.FindElement(By.CssSelector("#center_column > h1"));

        //User Header info = Users Login name = 'Stuart D'
        public IWebElement UserHdrInfo => Driver.FindElement(By.XPath("//*[text() = 'Stuart D']"));

        public IWebElement SignOutBtn => Driver.FindElement(By.CssSelector("div > nav > div:nth-child(2) > a"));
    }
}
