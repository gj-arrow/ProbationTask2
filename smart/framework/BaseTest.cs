﻿using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace demo.framework
{
    [TestClass]
    public class BaseTest : BaseEntity
    {
       [TestInitialize]
        public void SetUp()
       {
            Browser.GetInstance();
            Browser.GetDriver().Navigate().GoToUrl(Configuration.GetBaseUrl());
            //Browser.GetDriver().Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TearDown()
        {
            //var processes = Process.GetProcessesByName(Configuration.GetBrowser());
            //foreach (var process in processes)
            //{
            //    process.Kill();
            //}
            Browser.GetDriver().Quit();
        }
    }
}
