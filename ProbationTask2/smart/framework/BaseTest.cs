using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace demo.framework
{
    [TestClass]
    public class BaseTest : BaseEntity
    {
        protected int _step = 1;

        [TestInitialize]
        public void SetUp()
        {
            Browser.GetInstance();
            Browser.GetDriver().Navigate().GoToUrl(Configuration.GetBaseUrl());
        }

        [TestCleanup]
        public void TearDown()
        {
            Browser.GetDriver().Quit();
        }
    }
}
