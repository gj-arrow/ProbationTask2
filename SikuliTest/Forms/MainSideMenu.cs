using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;

namespace SikuliTest.Forms
{
    public class MainSideMenu : BaseForm
    {
        private Link linkMenuItem;
        private string _templateMenuLocator = "//div[contains(@class,'sidebar-buttons')]//a[contains(@title,'{0}')]";

        public MainSideMenu(By locator, string name) : base (locator, name)
        {
        }

        public void NavigateToMenuItem(MainMenuItems.TopLevelMenuItemEnum topMenuItem)
        {
            linkMenuItem = new Link(
                By.XPath(string.Format(_templateMenuLocator, EnumerableService.GetEnumDescription(topMenuItem))),
                "Link main side menu item:" + EnumerableService.GetEnumDescription(topMenuItem));
            if (linkMenuItem.IsDisplayed())
            {
                linkMenuItem.Click();
            }
        }
    }
}
