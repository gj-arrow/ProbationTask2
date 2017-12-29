using demo.framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SikuliTest.Forms;

namespace SikuliTest.Test
{
    [TestClass]
    public class SikuliTest : BaseTest
    {
        private readonly string _item = RunConfigurator.GetValue("item");
        private readonly string _itemViewFromAbove = RunConfigurator.GetValue("itemViewFromAbove");
        private readonly string _placeForItem = RunConfigurator.GetValue("placeForItem");
        private readonly string _deleteItem = RunConfigurator.GetValue("deleteButton");

        [TestMethod]
        public void TestSikuli()
        {
            Log.Step(_step++, "Navigate to Roomstyler.com");
            var mainF = new MainForm();
            var popupF = new PopupForm();

            Log.Step(_step++, "Close the dialog: Welcome to homestyler 3D home planner");
            popupF.CloseModalWindow();

            Log.Step(_step++, "The dialog is closed");
            Assert.IsTrue(mainF.IsClosedWindow(), "Modal window wasn't closed");

            Log.Step(_step++, "Open the main menu 'Finishing your room'");
            mainF.GetMainSideMenu().NavigateToMenuItem(MainMenuEnum.FURNISH_YOUR_ROOM);

            Log.Step(_step++, "List of items opens");
            mainF.IsDisplayedMenu();

            Log.Step(_step++, "Open the menu 'Dining room'");
            mainF.GetBrowseCategoryMenu().NavigateToMenuItem(FurnishMenuEnum.DINING_ROOM);

            Log.Step(_step++, "List of items opens");
            mainF.IsDisplayedMenu();

            Log.Step(_step++, "Select any Drag and Drop item and move it to the workspace");
            var sikuliActions = new SikuliActions();
            sikuliActions.Hover(_item);
            var expectedItemName = mainF.GetNameItemFromTooltip();
            sikuliActions.DragAndDrop(_item, _placeForItem);

            Log.Step(_step++, "Сheck that the item is correctly displayed in the workspace");
            Assert.IsTrue(sikuliActions.Exists(_itemViewFromAbove), "There is no element on the scene");

            Log.Step(_step++, "Сlick on the element and check the data");
            sikuliActions.Click(_itemViewFromAbove);
            var actualItemName = mainF.GetNameItemFromInfoSection();
            Assert.AreEqual(expectedItemName, actualItemName, "Expected name of item and actual item name not match");

            Log.Step(_step++, "Сheck the information about the element:name H0.81 m x W0.46 m x D0.54 m nonzero values");
            var characteristicsItem = mainF.GetCharacteristicsOfItem();
            Assert.IsTrue(mainF.IsPositiveCharacteristics(characteristicsItem), "One or more characteristics of item is zero");

            Log.Step(_step++, "Delete the item");
            sikuliActions.Click(_deleteItem);

            Log.Step(_step++, "Scene information is empty, 0 is displayed everywhere");
            Assert.IsTrue(mainF.IsAllFieldSceneInformationZero(), "Fields of information scene are not zero");
        }
    }
}

