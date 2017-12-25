using System.ComponentModel;

namespace SikuliTest.Forms
{
    public class MainMenuItems
    {
        public enum TopLevelMenuItemEnum
        {
            [Description("Build room layout")]
            BUILD_ROOM_LAYOUT,
            [Description("Furnish your room")]
            FURNISH_YOUR_ROOM,
            [Description("Decorate your room")]
            DECORATE_YOUR_ROOM,
            [Description("Manage lights")]
            MANAGE_LIGHTS,
            [Description("Populate your list")]
            POPULATE_YOUR_LIST,
            [Description("Properties")]
            PROPERTIES,
            [Description("Hide panel")]
            HIDE_PANEL
        }
    }
}
