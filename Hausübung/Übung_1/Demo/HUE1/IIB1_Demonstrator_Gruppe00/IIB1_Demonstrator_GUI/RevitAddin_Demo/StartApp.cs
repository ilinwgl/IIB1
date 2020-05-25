using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace IIB1_Demonstrator_GUI.RevitAddin_Demo
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
            }
            catch (Exception e)
            {
                TaskDialog.Show("IIB1 Demonstrator", e.ToString());
                return Result.Failed;
            }
            return Result.Succeeded;
        }
        #endregion

        #region Methods
        private void createRibbonPanel(UIControlledApplication application)
        {
            String panelName = "Meine Revit-Funktionen";
            RibbonPanel ribbonDemoPanel = application.CreateRibbonPanel(panelName);
            PushButton myButton = (PushButton)ribbonDemoPanel
                .AddItem(new PushButtonData("IIB1Demo", "IIB_Demonstrator", thisAssemblyPath, typeof(RevitAddinCommand).FullName));
            string ButtonIconsFolder = Path.GetDirectoryName(thisAssemblyPath);
            myButton.LargeImage = new BitmapImage(new Uri(Path.Combine(ButtonIconsFolder, "roomlist.png"), UriKind.Absolute));
            myButton.ToolTip = "Click to get the room schedule";
        }
        #endregion

    }
}
