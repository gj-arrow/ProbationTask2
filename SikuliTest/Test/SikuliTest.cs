using System;
using System.Threading;
using demo.framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SikuliSharp;
using SikuliTest.Forms;

namespace SikuliTest.Test
{
    [TestClass]
    public class SikuliTest : BaseTest
    {
        private readonly string item = RunConfigurator.GetValue("item");
        private readonly string itemViewFromAbove = RunConfigurator.GetValue("itemViewFromAbove");
        private readonly string placeForItem = RunConfigurator.GetValue("placeForItem");
        private readonly string deleteButton = RunConfigurator.GetValue("deleteButton");

        [TestMethod]
        public void TestSikuli()
        {
            Log.Step("Navigate to Roomstyler.com");
            MainForm mainF = new MainForm();
            Assert.IsTrue(mainF.isTruePage(), "This is not Main page");

            Log.Step("Close modal window");
            mainF.CloseModalWindow();

            Log.Step("Assert that modal window was closed");
            Assert.IsTrue(mainF.isClosedWindow(), "Modal window wasn't closed");

           // Thread.Sleep(500);
            Log.Step("");
            mainF.GetMainSideMenu().NavigateToMenuItem(MainMenuItems.TopLevelMenuItemEnum.FURNISH_YOUR_ROOM);

            //Thread.Sleep(500);
            Log.Step("");
            mainF.GetBrowseCategoryMenu().NavigateToMenuItem(FurnishMenuItems.TopLevelMenuItemEnum.DINING_ROOM);

            Log.Step("");
            SikuliActions sikuliActions = new SikuliActions();
            sikuliActions.Hover(item);
            var expectedItemName = mainF.GetNameItemFromPopup();
            sikuliActions.DragAndDrop(item, placeForItem);

            Log.Step("");
            Assert.IsTrue(sikuliActions.Exists(itemViewFromAbove), "There is no element on the scene");

            Log.Step("");
            sikuliActions.Click(itemViewFromAbove);

            var actualItemName = mainF.GetNameItemFromInfoSection();
            Assert.AreEqual(expectedItemName, actualItemName, "Expected name of item and actual item name not match");
            var characteristicsItem = mainF.GetCharacteristicsOfItem();
            Assert.IsTrue(mainF.IsPositiveCharacteristics(characteristicsItem), "One or more characteristics of item isn't positive");

            Log.Step("");
            sikuliActions.Click(deleteButton);

            //  Assert.IsTrue(!sikuliActions.Exists(itemViewFromAbove), "Item not removed from scene");
            Assert.IsTrue(mainF.IsAllFieldSceneInformationZero(), "Fields of information scene are not zero");
        }
    }
}

