using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdmAutotests.WebPages;
using IdmAutotests.WebPages.Root;
using IdmAutotests.Utilities;
using IdmAutotests.Tests.Properties;

namespace IdmAutotests.Tests
{
    [TestClass]
    public class LogOnTests : TestBase
    {
        [TestMethod]
        public void LogOnTest()
        {
            #region TestData
            const string EmptyUserName = null;
            const string EmptyPassword = null;
            const string CorrectUserName = "admin";
            const string CorrectPassword = "qwerty1234";
            #endregion

            Pages.LogOn.Open();
            Pages.LogOn.DoLogOn(EmptyUserName, EmptyPassword);
            string validationResult = Pages.LogOn.ValidationResult();
            Assert.IsTrue(validationResult.Contains(Settings.Default.emptyPassError));
            Assert.IsTrue(validationResult.Contains(Settings.Default.emptyUserNameError));
            Assert.IsTrue(validationResult.Contains(Settings.Default.incorCredentialsError));

            Pages.LogOn.DoLogOn("UserName", EmptyPassword);
            validationResult = Pages.LogOn.ValidationResult();
            Assert.IsTrue(validationResult.Contains(Settings.Default.emptyPassError));
            Assert.IsTrue(validationResult.Contains(Settings.Default.incorCredentialsError));

            Pages.LogOn.DoLogOn(EmptyUserName, "Password");
            validationResult = Pages.LogOn.ValidationResult();
            Assert.IsTrue(validationResult.Contains(Settings.Default.emptyUserNameError));
            Assert.IsTrue(validationResult.Contains(Settings.Default.incorCredentialsError));

            Pages.LogOn.DoLogOn("UserName", "Password");
            validationResult = Pages.LogOn.ValidationResult();
            Assert.IsTrue(validationResult.Contains(Settings.Default.incorCredentialsError));

            Pages.LogOn.DoLogOn("<UserName>", "Password");
            validationResult = Pages.LogOn.ValidationResult();
            Assert.IsTrue(validationResult.Contains(Settings.Default.tagError));
            Assert.IsTrue(validationResult.Contains(Settings.Default.incorCredentialsError));

         /*   Pages.LogOn.DoLogOn("aDmIn", CorrectPassword);
            validationResult = Pages.LogOn.ValidationResult();
            Assert.IsTrue(validationResult.Contains(Settings.Default.incorCredentialsError)); */

            Pages.LogOn.DoLogOn(CorrectUserName, CorrectPassword);                    
        }
    }
}
