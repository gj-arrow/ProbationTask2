using System;
using demo.framework;
using SikuliSharp;

namespace SikuliTest.Forms
{
    public class SikuliActions : BaseEntity
    {
        private readonly ISikuliSession _session = Sikuli.CreateSession();
        private readonly string _pathToProject = Environment.CurrentDirectory + "/../../Resources/ImagesForSikuli/";
        public void DragAndDrop(string image, string endPointImage)
        {
            var imageObject = Patterns.FromFile(_pathToProject + image);
            var place = Patterns.FromFile(_pathToProject + endPointImage);
            _session.DragAndDrop(imageObject, place);
            Log.Info(String.Format("{0} : drag and drop", image));
        }

        public void Hover(string image)
        {
            var imageObject = Patterns.FromFile(_pathToProject + image);
            _session.Hover(imageObject);
            Log.Info(String.Format("{0} : hover", image));
        }

        public bool Exists(string image)
        {
            var imageObject = Patterns.FromFile(_pathToProject + image);
            Log.Info(String.Format("{0} : exist", image));
            return _session.Exists(imageObject);
        }

        public void Click(string image)
        {
            var imageObject = Patterns.FromFile(_pathToProject + image);
            _session.Click(imageObject);
            Log.Info(String.Format("{0} : click", image));
        }
    }
}