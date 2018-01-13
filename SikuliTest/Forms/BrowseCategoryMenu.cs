using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;
using SikuliTest.Enumerable;

namespace SikuliTest.Forms
{
    public class BrowseCategoryMenu : BaseForm
    {
        private Link _linkMenuItem;
        private const string TemplateMenuLocator = "//div[contains(@class,'facet-category')]//a[contains(text(), '{0}')]";

        public BrowseCategoryMenu() : base(By.XPath("//div[@id='view-search']//div[contains(@class,'facet-category')]"),
            "Browse category menu")
        {
        }

        public void NavigateToMenuItem(FurnishMenuEnum menuItem)
        {
            _linkMenuItem = new Link(
                By.XPath(string.Format(TemplateMenuLocator, menuItem.GetStringMapping())), 
                "Link browse category menu item:" + menuItem.GetStringMapping());
            _linkMenuItem.Click();
        }
    }
}
