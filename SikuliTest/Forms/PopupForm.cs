using demo.framework.Elements;
using demo.framework.forms;
using OpenQA.Selenium;

namespace SikuliTest.Forms
{
    public class PopupForm : BaseForm
    {
        private readonly Button _btnCloseWelcomeWindow = 
            new Button(By.XPath(@"//div[@id='popin-content-holder']//a[contains(@class,'popin-close-title')]"),"Button Close popup");

        public PopupForm()
            : base(By.Id("popin-content"), "Dialog: Welcome to homestyler 3D home planner")
        {
        }

        public void CloseModalWindow()
        {
            _btnCloseWelcomeWindow.Click();
        }
    }
}
