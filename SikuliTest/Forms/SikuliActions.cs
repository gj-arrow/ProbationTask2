using System;
using SikuliSharp;

namespace SikuliTest.Forms
{
    public class SikuliActions
    {
        ISikuliSession session = Sikuli.CreateSession();
        string pathToProject = Environment.CurrentDirectory;
        public void DragAndDrop(string Image, string endPointImage)
        {
            var image = Patterns.FromFile(pathToProject + Image);
            var place = Patterns.FromFile(pathToProject + endPointImage);
            session.DragDrop(image, place);
        }

        public void Hover(string Image)
        {
            var imageObject = Patterns.FromFile(pathToProject + Image);
            session.Hover(imageObject);
        }

        public bool Exists(string Image)
        {
            var imageObject = Patterns.FromFile(pathToProject + Image);
            return session.Exists(imageObject);
        }

        public void Click(string Image)
        {
            var imageObject = Patterns.FromFile(pathToProject + Image);
            session.Click(imageObject);
        }
    }
}