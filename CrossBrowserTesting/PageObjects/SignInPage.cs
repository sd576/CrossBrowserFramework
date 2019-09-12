using OpenQA.Selenium;

namespace CrossBrowserTesting.PageObjects
{
    class SignInPage
    {
        public SignInPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        //Page Title = 'Login - My Store'
        public string PageTitle => Driver.Title;

        //Page Heading = 'Authentication'
        public IWebElement PageHeading => Driver.FindElement(By.CssSelector("#center_column > h1"));
        public IWebElement EmailAddressField => Driver.FindElement(By.Id("email"));
        public IWebElement PasswordField => Driver.FindElement(By.Id("passwd"));
        public IWebElement SignInButton => Driver.FindElement(By.Id("SubmitLogin"));

        public IWebElement BlankEmailMessage => Driver.FindElement(By.CssSelector("#center_column > div.alert.alert-danger > ol > li"));
        public IWebElement BlankPasswordMessage => Driver.FindElement(By.CssSelector("#center_column > div.alert.alert-danger > ol > li"));
        public IWebElement InvalidEmailMessage => Driver.FindElement(By.CssSelector("#center_column > div.alert.alert-danger > ol > li"));
        public IWebElement InvalidPasswordMessage => Driver.FindElement(By.CssSelector("#center_column > div.alert.alert-danger > ol > li"));


        public SignInPage LoginAs(string username, string password)
        {
            EmailAddressField.SendKeys(username);
            PasswordField.SendKeys(password);
            SignInButton.Click();
            return new SignInPage(Driver);
        }

        public SignInPage LoginUnsuccessfullyAs(string username, string password)
        {
            LoginAs(username, password);
            return this;
        }

        public string GetBlankEmailMessage()
        {
            return BlankEmailMessage.Text;
        }

        public string GetBlankPasswordMessage()
        {
            return BlankPasswordMessage.Text;
        }

        public string GetInvalidEmailMessage()
        {
            return InvalidEmailMessage.Text;
        }

        public string GetInvalidPasswordMessage()
        {
            return InvalidPasswordMessage.Text;
        }

        private void SignIn(string username, string password)
        {
            EmailAddressField.SendKeys(username);
            PasswordField.SendKeys(password);
            SignInButton.Click();
        }
    }
}