using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;

namespace SikuliTest.Forms
{
   public class MainForm : BaseForm
    {
      
        private readonly TextBox _txtWelcomeWindow = new TextBox(By.Id("popin-content-holder"),
           "Modal window");
        private readonly Link _linkNameItem = new Link(By.XPath("//div[contains(@class,'popup-content')]//h3"),
        "Hovered item name");
        private readonly Link _linkIsDisplayedMenu = new Link(By.XPath("//div[@id='view-search']//div[contains(@class,'facet-category')]"),
            "Hovered item name");
        private readonly Link _linkNameItemFromInfoSection = new Link(By.XPath("//div[contains(@class,'component empty')]//p[contains(@class,'name')]"),
       "Actual item name from info section");
        private readonly Link _linkCharacteristicksItem = 
            new Link(By.XPath("//div[contains(@class,'component-data available')]//p[contains(@class,'dimensions')]"), "Characteristics of item");
        private readonly Link _informationScene =
           new Link(By.XPath("//div[contains(@class,'scene')]//b"), "Informarions scene");
        private readonly MainSideMenu _mainSideMenu = new MainSideMenu();
        private readonly BrowseCategoryMenu _browseCategoryMenu =  new BrowseCategoryMenu();
        private const string RegularFindCharacteristicsItem = @"[^\D]\.?\d+";
        private const string Zero = "0";
        public MainForm()
            : base(By.XPath("//div[@id='view-floor']//div[contains(@class,'canvas')]"), "Main Roomstyler Form")
        {
        }

        public bool IsClosedWindow()
        {
            return !_txtWelcomeWindow.IsPresent();
        }

        public bool IsDisplayedMenu()
        {
            return _linkIsDisplayedMenu.IsDisplayed();
        }

        public string GetNameItemFromTooltip()
        {
            return _linkNameItem.GetText();
        }

        public string GetNameItemFromInfoSection()
        {
            return _linkNameItemFromInfoSection.GetText();
        }

        public MainSideMenu GetMainSideMenu()
        {
            return _mainSideMenu;
        }

        public BrowseCategoryMenu GetBrowseCategoryMenu()
        {
            return _browseCategoryMenu;
        }

        public List<string> GetCharacteristicsOfItem()
        {
           var characteristicsItemList = new List<string>();
            var characteristicsString =  _linkCharacteristicksItem.GetText();
            foreach (Match match in Regex.Matches(characteristicsString, RegularFindCharacteristicsItem, RegexOptions.IgnoreCase))
            {
                characteristicsItemList.Add(match.Value);
            }
            return characteristicsItemList;
        }

        public bool IsPositiveCharacteristics(List<string> characteristicsItem)
        {
           return characteristicsItem.All(i => i != Zero);
        }

        public bool IsAllFieldSceneInformationZero()
        {
            return _informationScene.FindElements().All(i => i.Text == Zero);
        }
    }
}