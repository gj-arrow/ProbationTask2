using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;

namespace SikuliTest.Forms
{
    public class BrowseCategoryMenu : BaseForm
    {
        private Link linkMenuItem;
        private string _templateMenuLocator = "//div[contains(@class,'facet-category')]//a[contains(text(), '{0}')]";

        public BrowseCategoryMenu(By locator, string name) : base(locator, name)
        {
        }

        public void NavigateToMenuItem(FurnishMenuItems.TopLevelMenuItemEnum topMenuItem)
        {
            linkMenuItem = new Link(
                By.XPath(string.Format(_templateMenuLocator, EnumerableService.GetEnumDescription(topMenuItem))), 
                "Link vrowse category menu item:" + EnumerableService.GetEnumDescription(topMenuItem));
            if (linkMenuItem.IsDisplayed())
            {
                linkMenuItem.Click();
            }
        }
    }
}
