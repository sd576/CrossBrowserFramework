using CrossBrowserTesting.PageObjects;
using NUnit.Framework;
using CrossBrowserTesting.Tests;

namespace CrossBrowserTesting
{
    [TestFixture]
    [Parallelizable]

    //A basic cross browser test that calls up different browsers, logs into the website 'automationpractice.com',
    //asserts that the HomePage, SignInPage and the MyAccountPage are all called successfully and the Users account name
    //is correctly displayed on the MyAccountPage
    public class LoginAndOut : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowserForTest")]
        public void LoginOutTest(string browserName)
        {
            BeforeEveryTest(browserName);

            //WaitForHomePage();
            HomePage homePage = new HomePage(driver);
            homePage.SignInBtn.Click();

            //WaitForSignInPage();
            SignInPage signInPage = new SignInPage(driver);
            Assert.AreEqual("Login - My Store", driver.Title);

            signInPage.EmailAddressField.SendKeys("Stuart@me.com");
            signInPage.PasswordField.SendKeys("Password01");
            signInPage.SignInButton.Click();

            //WaitForMyAccountPage();
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            Assert.AreEqual("My account - My Store", driver.Title);

            //Assert that the Users login is displayed on the screen
            Assert.IsTrue(myAccountPage.UserHdrInfo.Text.Contains("Stuart D"));

            myAccountPage.SignOutBtn.Click();

            //WaitForHomePage();
            Assert.AreEqual("Login - My Store", driver.Title);
        }
    }
}