using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace IdmAutotests.Tests
{

    [TestFixture]

    public class ChangingAttribute
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;


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
        public void TheChangingAttribute()
        {
            //IdM authorization page
            driver.Navigate().GoToUrl(baseURL + "/idsrv");
            Thread.Sleep(1500);

            //Changing attribute login field size
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            IWebElement login = FindElement(By.XPath("//*[@id='UserName']"));
            js.ExecuteScript("document.getElementById('UserName').setAttribute('class', 'text-box single-line textLage')");

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
