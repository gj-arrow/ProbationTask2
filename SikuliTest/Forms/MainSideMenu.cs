using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;
using SikuliTest.Enumerable;

namespace SikuliTest.Forms
{
    public class MainSideMenu : BaseForm
    {
        private Link _linkMenuItem;
        private const string TemplateMenuLocator = "//div[contains(@class,'sidebar-buttons')]//a[contains(@title,'{0}')]";

        public MainSideMenu() : base(By.XPath("//div[@id='sidebar']//div[contains(@class,'sidebar-buttons')]"),
            "Main side menu")
        {
        }

        public void NavigateToMenuItem(MainMenuEnum menuItem)
        {
            _linkMenuItem = new Link(
                By.XPath(string.Format(TemplateMenuLocator, menuItem.GetStringMapping())),
                "Link main side menu item:" + menuItem.GetStringMapping());
            _linkMenuItem.Click();
        }
    }
}
