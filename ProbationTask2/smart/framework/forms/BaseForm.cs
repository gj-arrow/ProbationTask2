using System;
using OpenQA.Selenium;
using demo.framework.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace demo.framework.forms
{
    public class BaseForm : BaseEntity
    {
        private readonly string _name;
        private readonly By _locator;
        private TextBox _element;
        protected BaseForm(By locator, String name)
        {   _locator = locator;
            _name = name;
            AssertIsPresent();
            Assert.IsTrue(IsTruePage(), "This is not Main page");
        }

        private void AssertIsPresent()
        {
            BaseElement.WaitForElementPresent(_locator, "Form " + _name);
            Log.Info(String.Format("Form '{0}' has appeared", _name));
        }

        public void CheckTextOnForm(String text)
        {
            BaseElement.WaitForElementPresent(By.XPath("//*[contains(.,'" + text + "')]"), text);
            Log.Info(String.Format("Text '{0}' is shown on the page", text));
        }

        public bool IsTruePage()
        {
            _element = new TextBox(_locator, "Element defined the page");
            return _element.IsPresent();
        }
    }
}
