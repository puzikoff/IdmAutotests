using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdmAutotests.WebPages;
using IdmAutotests.WebPages.Root;
using IdmAutotests.Utilities;

namespace IdmAutotests.Tests
{
    [TestClass]
    public class LogOnTest : TestBase
    {
        [TestMethod]
        public void EmptyFields()
        {
            #region TestData
            const string UserName = null;
            const string Password = null;
            #endregion

            Pages.LogOn.Open();
        //    Browser.SaveScreenshot("D:\\");
            Pages.LogOn.DoLogOn(UserName, Password);
       
        }
    }
}
