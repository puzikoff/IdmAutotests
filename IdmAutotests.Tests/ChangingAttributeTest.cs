using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IdmAutotests.WebPages;
using IdmAutotests.WebPages.Root;
using IdmAutotests.Utilities;
using IdmAutotests.Tests.Properties;

namespace IdmAutotests.Tests
{
    [TestClass]
    public class ChangingAttributeTest : TestBase
    {
        [TestMethod]
        public void ChangingLoginFieldSize()
        {
            Pages.LogOn.Open();
            Browser.ExecuteJavaScript("document.getElementById('UserName').setAttribute('class', 'text-box single-line textLage')");
            Thread.Sleep(1500);
        }
    }
}
