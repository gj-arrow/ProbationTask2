using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace demo.framework.Elements
{
    public abstract class BaseElement : BaseEntity
    {
        private readonly RemoteWebElement _element;
        private readonly string _name;
        private readonly By _locator;
        public WebDriverWait Wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(Convert.ToDouble(Configuration.GetTimeout())));

        protected BaseElement(By locator, String name)
        {
            this._name = name;
            this._locator = locator;
        }

        protected RemoteWebElement GetElement()
        {   
            WaitForElementPresent();
            return (RemoteWebElement)Browser.GetDriver().FindElement(_locator); ;
        }

        protected String GetName()
        {
            return _name;
        }

        protected By GetLocator()
        {
            return _locator;
        }

        public string GetText()
        {
            WaitForElementPresent();
            return Browser.GetDriver().FindElement(_locator).Text;
        }

        public void Click()
        {
            WaitForElementPresent();
            WaitForElementDisplayed();
            GetElement().Click();
            //Browser.WaitForPageToLoad();
            Log.Info(String.Format("{0} : click :", GetName()));
        }

        public Boolean IsPresent()
        {
            bool isPresent = Browser.GetDriver().FindElements(_locator).Count > 0;
            Log.Info(GetName() + " : is present : " + isPresent);
            return isPresent;
        }

        public Boolean IsDisplayed()
        {
            bool isDisplayed = Browser.GetDriver().FindElement(_locator).Displayed;
            Log.Info(GetName() + " : is displaye : " + isDisplayed);
            return isDisplayed;
        }

        public List<IWebElement> FindElements()
        {
            return Browser.GetDriver().FindElements(_locator).ToList();
        }

        //public void WaitUntilClickable()
        //{
        //    WaitForElementDisplayed();
        //    Wait.Until(ExpectedConditions.ElementToBeClickable(_locator));
        //}

        protected void WaitForElementDisplayed()
        {
            var wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    var webElements = Browser.GetDriver().FindElement(_locator).Displayed;
                    return webElements == true;
                });
            }
            catch (TimeoutException)
            {
                Log.Fatal(string.Format("Element with locator: '{0}' does not displayed!", _locator));
            }
        }

        protected void WaitForElementPresent()
        {
            var wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    var webElements = Browser.GetDriver().FindElements(_locator);
                    return webElements.Count != 0;
                });
            }
            catch (TimeoutException)
            {
                Log.Fatal(string.Format("Element with locator: '{0}' does not exists!", _locator));
            }
        }

        public static void WaitForElementPresent(By locator, String name)
        {
            var wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    try
                    {
                        var webElements = Browser.GetDriver().FindElements(locator);
                        return webElements.Count != 0;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                });
            }
            catch (TimeoutException)
            {
                Log.Fatal(string.Format("Element with locator: '{0}' does not exists!", locator));
            }
        }
    }
}
