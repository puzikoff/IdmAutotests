using IdmAutotests.Utilities;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdmAutotests.Tests
{
    [TestClass]
    public abstract class TestBase
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Browser.Start();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Browser.Quit();
        }
    }
}
