using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    
    [TestFixture]

    public class RegistrationTest
    {
        /*GitHub try*/
        /*Commit from Visual studio*/
        /*Commit from Visual studio 2*/
        /*BitBucket*/
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        string emptyUserNameError = "The User name field is required.";
        string emptyPassError = "The Password field is required.";
        string incorCredentialsError = "Incorrect credentials or no authorization.";
        string tagError = "A potentially dangerous Request.Form value was detected from the client";

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://WIN-CV4AVBPAV8A/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheRegistrationTest()
        {
            //IdM authorization page
            driver.Navigate().GoToUrl(baseURL + "/idsrv");
            Thread.Sleep(1500);

            //Empty UserName and Password
            ElementClick(By.Name("submit.Save"));
            Thread.Sleep(1500);
            //validation
            IWebElement alert = FindElement(By.XPath("//form/div[1]/ul/li[1]"));
            Assert.True(alert.Text == emptyPassError);
            alert = FindElement(By.XPath("//form/div[1]/ul/li[2]"));
            Assert.True(alert.Text.Contains(emptyUserNameError));
            alert = FindElement(By.XPath("//form/div[1]/ul/li[3]"));
            Assert.True(alert.Text == incorCredentialsError);

            //Emty password
            EnterUserNameAndPassword("userName", "");
            ElementClick(By.Name("submit.Save"));
            //validation
            alert = FindElement(By.XPath("//form/div[1]/ul/li[1]"));
            Assert.True(alert.Text == "The Password field is required.");
            alert = FindElement(By.XPath("//form/div[1]/ul/li[2]"));
            Assert.True(alert.Text == incorCredentialsError);

            //Empty UserName
            EnterUserNameAndPassword("", "password");
            ElementClick(By.Name("submit.Save"));
            //validation
            alert = FindElement(By.XPath("//form/div[1]/ul/li[1]"));
            Assert.True(alert.Text == emptyUserNameError);
            alert = FindElement(By.XPath("//form/div[1]/ul/li[2]"));
            Assert.True(alert.Text == incorCredentialsError);

            //Incorrect credentials
            EnterUserNameAndPassword("UserName", "Password");
            ElementClick(By.Name("submit.Save"));
            //validation
            alert = FindElement(By.XPath("//form/div[1]/ul/li[1]"));
            Assert.True(alert.Text == incorCredentialsError);

            //UserName with tag
            EnterUserNameAndPassword("<username>", "password");
            ElementClick(By.Name("submit.Save"));
            //validation
            alert = FindElement(By.XPath("//form/div[1]/ul/li[1]"));
            Assert.True(alert.Text.Contains(tagError));
            alert = FindElement(By.XPath("//form/div[1]/ul/li[2]"));
            Assert.True(alert.Text == incorCredentialsError);

            //Correct UserName. Password with symbol in different case
            EnterUserNameAndPassword("AdMin", "qwerTy1234");
            ElementClick(By.Name("submit.Save"));

            //Correct credentials
            EnterUserNameAndPassword("admin", "qwerty1234");
            ElementClick(By.Name("submit.Save"));
            Thread.Sleep(1500);
            //validation
            alert = FindElement(By.XPath("//h1"));
            Assert.True(alert.Text.Contains("Dashboard"));
        }

        private void EnterUserNameAndPassword(string userName, string password)
        {
            driver.FindElement(By.Id("UserName")).Clear();
            driver.FindElement(By.Id("UserName")).SendKeys(userName);
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys(password);
        }

        private IWebElement FindElement(By locator)
        {
            return driver.FindElement(locator);
        }

        private void ElementClick(By locator)
        {
            driver.FindElement(locator).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
