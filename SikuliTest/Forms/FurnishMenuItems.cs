using System.ComponentModel;

namespace SikuliTest.Forms
{
    public class FurnishMenuItems
    {
        public enum TopLevelMenuItemEnum
        {
            [Description("Dining room")]
            DINING_ROOM,
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
