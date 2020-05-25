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
//using ClassRoom = IIB1_Demonstrator_ClassLibrary.Classes.Room;
using IIB1_Demonstrator_ClassLibrary.Classes;
using IIB1_Demonstrator_GUI.Forms;

namespace IIB1_Demonstrator_RevitAddin
{
    
    public class StartApp : IExternalApplication
    {
        #region Attribute
        // ExternalCommands assembly path
        static string thisAssemblyPath = typeof(StartApp).Assembly.Location;
        #endregion

        #region Interface Methods
        public Result OnShutdown(UIControlledApplication application)
        {         
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                createRibbonPanel(application);
                return Result.Succeeded;
            }
            catch(Exception e)
            {
                TaskDialog.Show("IIB1 Demonstrator", e.ToString());
                return Result.Failed;
            }           
        }
        #endregion

        #region Methods
        private void createRibbonPanel(UIControlledApplication application)
        {
            String panelName = "Meine Revit-Funktionen";
            RibbonPanel ribbonDemoPanel = application.CreateRibbonPanel(panelName);
            PushButton myButton = (PushButton)ribbonDemoPanel
                .AddItem(new PushButtonData("IIB1Demo", "IIB_Demonstrator", thisAssemblyPath, typeof(RevitAddin).FullName));
            string ButtonIconsFolder = Path.GetDirectoryName(thisAssemblyPath);
            myButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "roomlist.png"), UriKind.Absolute));
            myButton.ToolTip = "Click to get the room schedule";
        }
        #endregion

    
    }
}
