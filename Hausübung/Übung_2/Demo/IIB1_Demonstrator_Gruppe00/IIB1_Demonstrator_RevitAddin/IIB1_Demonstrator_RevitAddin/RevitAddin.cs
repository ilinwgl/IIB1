using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System.ComponentModel;
using IIB1_Demonstrator_ClassLibrary.Classes;
using ClassFloor = IIB1_Demonstrator_ClassLibrary.Classes.Floor;
using IIB1_Demonstrator_GUI.Forms;

using System.IO;
using System.Windows.Media.Imaging;
using ClassRoom = IIB1_Demonstrator_ClassLibrary.Classes.Room;
using RevitRoom = Autodesk.Revit.DB.Architecture.Room;
using System.Linq;
using Autodesk.Revit.DB.Structure;

namespace IIB1_Demonstrator_RevitAddin
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class RevitAddin : IExternalCommand
    {
        // ModelessForm instance
        public static FormStart _demoForm;
        private static Document _doc;
        private static UIDocument _uidoc;
        private static ExternalCommandData _ecd;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                _ecd = commandData;
                BindingList<Building> buildings = new BindingList<Building>();
                UIApplication uiApp = commandData.Application;
                _uidoc = uiApp.ActiveUIDocument;
                _doc = Util.Doc = _uidoc.Document;

                buildings.Add(Util.parseBuilding());

                if (_demoForm != null && _demoForm.Visible)
                {
                    _demoForm.Close();
                    _demoForm = null;
                }

                ShowForm(buildings);
                return Autodesk.Revit.UI.Result.Succeeded;
            }
            catch (Exception e)
            {
                TaskDialog.Show("Revit", e.ToString());
                return Result.Failed;
            }
        }

        public void ShowForm(BindingList<Building> buildings)
        {
            if (_demoForm == null || _demoForm.IsDisposed)
            {
                RoomInfoUpdater updateHandler = new RoomInfoUpdater();
                ExternalEvent updateEvent = ExternalEvent.Create(updateHandler);
                TelPlacer lampPlacer = new TelPlacer();
                ExternalEvent placeEvent = ExternalEvent.Create(lampPlacer);

                _demoForm = new FormStart(updateEvent, placeEvent, buildings);
                _demoForm.Show();
            }
        }

        #region Buildigns Generattion-Method from Program.cs HUE2

        private static BindingList<Building> expGenerate(BindingList<Building> buildings)
        {
            Random rd = new Random();

            for (int i = 0; i < 3; i++)
            {
                string name = "Building " + rd.Next(1, 4).ToString() + "a";
                string adress = rd.Next(1, 75).ToString() + "Street";
                int levelnumber = rd.Next(1, 5);
                BindingList<ClassFloor> floors = new BindingList<ClassFloor>();
                for (int j = 0; j < levelnumber; j++)
                {
                    string vname = j.ToString();
                    string levelname = "Floor" + vname;
                    int officenumber = rd.Next(1, 4);
                    int livenumber = rd.Next(1, 4);

                    BindingList<ClassRoom> rooms = new BindingList<ClassRoom>();

                    for (int k = 0; k < officenumber; k++)
                    {
                        string offname = "Office " + vname + k.ToString();
                        double area = Math.Round(rd.NextDouble() * rd.Next(50, 100), 1);
                        rooms.Add(new Office(offname, area));
                    }

                    for (int k = 0; k < livenumber; k++)
                    {
                        string livename = "Livingroom " + vname + k.ToString();
                        double area = Math.Round(rd.NextDouble() * rd.Next(50, 100), 1);
                        rooms.Add(new Livingroom(livename, area));
                    }
                    floors.Add(new ClassFloor(levelname, rooms));
                }
                buildings.Add(new Building(name, adress, floors));
            }
            return buildings;
        }
        #endregion

        #region Event Handler
        public class RoomInfoUpdater : IExternalEventHandler
        {
            public static readonly string typeofuse = "Nutzungsgruppe DIN 277-2";

            public void Execute(UIApplication app)
            {
                update(_demoForm.Buildingdetails._clr);
            }

            private static void update(ClassRoom _clr)
            {
                if (_clr != null)
                {
                    try
                    {
                        //ClassRoom _clr = null;
                        bool worked;
                        if (_clr.Identity != null)
                        {
                            RevitRoom room = (RevitRoom)_doc.GetElement(_clr.Identity);
                            using (Transaction trans = new Transaction(_doc))
                            {
                                if (trans.Start("Change Room Parameters") == TransactionStatus.Started)
                                {
                                    room.Name = _clr.Name;
                                    worked = room.GetParameters(typeofuse).First().Set(idenfifyTyp(_clr));
                                    trans.Commit();
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        TaskDialog.Show("RoomInfoUpdater", e.Message);
                    }
                }
                else
                {
                    TaskDialog.Show("RoomInfoUpdater", "Please select a Room!");
                }
            }

            private static string idenfifyTyp(ClassRoom r)
            {
                if (r is Office)
                    return "2-Büroarbeit";
                else if (r is Livingroom)
                    return "1 - Wohnen und Aufenthalt";
                else return "";
            }

            public string GetName()
            {
                return "Update Room Information";
            }
        }

        public class TelPlacer : IExternalEventHandler
        {
            public void Execute(UIApplication app)
            {
                placeTel(_demoForm.Buildingdetails._clr);
            }

            private void placeTel(ClassRoom clr)
            {
                XYZ locR = _ecd.Application.ActiveUIDocument.Selection.PickPoint("Pick a point to place Telefon.");
                // RevitRoom rr = _doc.GetElement(clr.Identity) as RevitRoom;
                //XYZ locR = ((LocationPoint)rr.Location).Point;
                if (null != locR)
                {
                    using (Transaction trans = new Transaction(_doc))
                    {
                        if (trans.Start("PlaceFamily") == TransactionStatus.Started)
                        {

                        FamilyInstance fi = _doc.Create.NewFamilyInstance(locR,
                            GetFamilySymbolByName(BuiltInCategory.OST_SpecialityEquipment, "Telefon")
                            , StructuralType.NonStructural);
                        trans.Commit();
                    }
                }
               }
            }
            private static FamilySymbol GetFamilySymbolByName(BuiltInCategory bic, string name)
            {
                return new FilteredElementCollector(_doc).OfCategory(bic).OfClass(typeof(FamilySymbol))
                    .FirstOrDefault<Element>(e => e.Name.Equals(name)) as FamilySymbol;
            }

            public string GetName()
            {
                return "TelefonPlatzierer";

            }
        }
        #endregion
    }
}
