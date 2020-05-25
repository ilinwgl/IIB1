using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;

namespace IIB1_HUE2_Gruppe31_RevitAddin
{

    public class IIB1_Gruppe31_StartApp : IExternalApplication
    {
        static string path = typeof(IIB1_Gruppe31_StartApp).Assembly.Location;

        public Result OnStartup(UIControlledApplication application)
        {
            //Create a custom ribbon tab
            String tabName = "IIB1_Gruppe_31";
            application.CreateRibbonTab(tabName);

            //Create a ribbon panel
            RibbonPanel gruppe31_Panel = application.CreateRibbonPanel(tabName, "IIB1_Gruppe_31");

            //Create two push buttons
            PushButton button1 = (PushButton)gruppe31_Panel.AddItem(new PushButtonData("Button1", "Räume Manager", path, typeof(IIB1_Gruppe31_RevitAddin).FullName));
            button1.ToolTip = "Räume-Manager-Application eröffnen";

            return Result.Succeeded;
        }

   

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

    }
}
