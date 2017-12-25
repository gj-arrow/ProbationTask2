using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using demo.framework;
using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;

namespace SikuliTest.Forms
{
   public class MainForm : BaseForm
    {
        private Button btnCloseWelcomeWindow = new Button(By.XPath(@"//div[@id='popin-content-holder']//a[contains(@class,'popin-close-title')]"), 
            "Button Close Welcome Window");
        private TextBox txtWelcomeWindow = new TextBox(By.Id("popin-content-holder"),
           "Modal window");
        private TextBox txtCanvas = new TextBox(By.XPath("//div[@id='view-floor']//div[contains(@class,'canvas')]"),
          "Element defining the page");
        private Link linkNameItem = new Link(By.XPath("//div[contains(@class,'popup-content')]//h3"),
        "Hovered item name");
        private Link linkNameItemFromInfoSection = new Link(By.XPath("//div[contains(@class,'component empty')]//p[contains(@class,'name')]"),
       "Actual item name from info section");
        private Link linkCharacteristicksItem = 
            new Link(By.XPath("//div[contains(@class,'component-data available')]//p[contains(@class,'dimensions')]"), "Characteristics of item");
        private Link informationScene =
           new Link(By.XPath("//div[contains(@class,'scene')]//b"), "Informarions scene");
        private readonly MainSideMenu mainSideMenu = new MainSideMenu(By.XPath("//div[@id='sidebar']//div[contains(@class,'sidebar-buttons')]"),
            "Main side menu");
        private readonly BrowseCategoryMenu browseCategoryMenu = 
            new BrowseCategoryMenu(By.XPath("//div[@id='view-search']//div[contains(@class,'facet-category')]"),
           "Main side menu");
        private const string RegularFindCharacteristicsItem = @"[^\D]\.?\d+";

        public MainForm()
            : base(By.XPath("//div[@id='view-floor']//div[contains(@class,'canvas')]"), "Main Roomstyler Form")
        {
        }

        public void CloseModalWindow()
        {
            btnCloseWelcomeWindow.Click();
        }

        public bool isClosedWindow()
        {
            return !txtWelcomeWindow.IsPresent();
        }

        public string GetNameItemFromPopup()
        {
            return linkNameItem.GetText();
        }

        public string GetNameItemFromInfoSection()
        {
            return linkNameItemFromInfoSection.GetText();
        }

        public bool isTruePage()
        {
            return txtCanvas.IsPresent();
        }

        public MainSideMenu GetMainSideMenu()
        {
            return mainSideMenu;
        }

        public BrowseCategoryMenu GetBrowseCategoryMenu()
        {
            return browseCategoryMenu;
        }

        public List<string> GetCharacteristicsOfItem()
        {
            List<string> characteristicsItemList = new List<string>();
            var characteristicsString =  linkCharacteristicksItem.GetText();
            foreach (Match match in Regex.Matches(characteristicsString, RegularFindCharacteristicsItem, RegexOptions.IgnoreCase))
            {
                characteristicsItemList.Add(match.Value);
            }
            return characteristicsItemList;
        }

        public bool IsPositiveCharacteristics(List<string> characteristicsItem)
        {
            foreach (var characteristic in characteristicsItem)
            {
                if (characteristic == "0")
                    return false;
            }
            return true;
        }

        public bool IsAllFieldSceneInformationZero()
        {
            var ElementsFromInformationScene = informationScene.FindElements();
            foreach (var element in ElementsFromInformationScene)
            {
                if (element.Text == "0")
                    return true;
            }
            return false;
        }
    }
}