using OpenQA.Selenium;

namespace CrossBrowserTesting.PageObjects
{
    class HomePage
    {
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        //Page Title = 'My Store'
        public string PageTitle => Driver.Title;

        //Page Heading = 'Popular'
        public IWebElement PageHeading => Driver.FindElement(By.CssSelector("li.active > a"));
        public IWebElement SignInBtn => Driver.FindElement(By.ClassName("login"));

        internal void Open()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }
    }
}