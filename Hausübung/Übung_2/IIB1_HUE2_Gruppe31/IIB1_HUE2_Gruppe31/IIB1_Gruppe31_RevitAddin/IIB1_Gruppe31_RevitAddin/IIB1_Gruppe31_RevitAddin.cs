using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Architecture;
using System.ComponentModel;
using IIB1_Gruppe31_Klassen;
using ClassFloor = IIB1_Gruppe31_Klassen.Floor;
using IIB1_Gruppe31_GUI;
using System.IO;
using System.Windows.Media.Imaging;
using ClassRaum = IIB1_Gruppe31_Klassen.Raum;
using RevitRoom = Autodesk.Revit.DB.Architecture.Room;
using System.Linq;
using Autodesk.Revit.DB.Structure;
using PlaceData = IIB1_Gruppe31_GUI.Form1.PlaceData;

namespace IIB1_HUE2_Gruppe31_RevitAddin
{
    [Transaction(TransactionMode.Manual)]
    class IIB1_Gruppe31_RevitAddin : IExternalCommand
    {
        // ModelessForm instance
        public static Form0 _demoForm;
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
                _doc = IIB1_Gruppe31_Util.Doc = _uidoc.Document;

                buildings.Add(IIB1_Gruppe31_Util.parseBuilding());

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
            #region eröffnen Form0
            if (_demoForm == null || _demoForm.IsDisposed)
            {
                RoomInfoUpdater updateHandlerR = new RoomInfoUpdater();
                MoebelInfoUpdater updateHandlerM = new MoebelInfoUpdater();
                ExternalEvent updateEventR = ExternalEvent.Create(updateHandlerR);
                ExternalEvent updateEventM = ExternalEvent.Create(updateHandlerM);
                TischPlacer tischPlacer = new TischPlacer();
                ExternalEvent placeEvent = ExternalEvent.Create(tischPlacer);

                _demoForm = new Form0(updateEventR, updateEventM, placeEvent, buildings);
                _demoForm.Show();
            }
            #endregion
        }

        #region Event Handler
        public class RoomInfoUpdater : IExternalEventHandler
        {
            #region Event Handler für Raum verändern
            public static readonly string typeofuse = "Nutzungsgruppe DIN 277-2";

            public void Execute(UIApplication app)
            {
                update(_demoForm.F1._clr);
            }

            private static void update(ClassRaum _clr)
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

                                    worked = room.GetParameters("Bereich").First().Set(_clr.Bereich);
                                    worked &= room.GetParameters("Besitzer").First().Set(_clr.Besitzer);
                                    worked &= room.GetParameters("Mieter").First().Set(_clr.Mieter);
                                    worked &= room.GetParameters("Miete").First().Set(_clr.Miete);
                                    worked &= room.GetParameters("Sitzplätze").First().Set(_clr.AnzahlSitzplaetze);
                                    worked &= room.GetParameters("Arbeitsplätze").First().Set(_clr.AnzahlArbeitsplaetze);
                                    worked &= room.GetParameters("Automat").First().Set(_clr.AnzahlAutomaten);
                                    string v;
                                    if (_clr.Vermieten == true)
                                    {
                                        v = "Ja";
                                    }
                                    else { v = "Nein"; }
                                    worked &= room.GetParameters("Mieten").First().Set(v);
                                    worked &= room.GetParameters(typeofuse).First().Set(idenfifyTyp(_clr));

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

            private static string idenfifyTyp(ClassRaum r)
            {
                if (r is Buero)
                    return "2-Büroarbeit";
                else if (r is Flur)
                    return "9-Verkehrserschl./sicherung";
                else if (r is Lagern)
                    return "4-Lagern/Verteilen/Verkaufen";
                else if (r is Ruheraum)
                    return "3-Produktion/Hand-Maschinenarbeit/Experiment";
                else if (r is Wohnenraum)
                    return "1-Wohnen und Aufenthalt";
                else if (r is Technischraum)
                    return "8-Technische Anlagen";
                else if (r is Sanitaerraum)
                    return "7-Sonstige Nutzflächen";
                else return "";
            }

            public string GetName()
            {
                return "Update Room Information";
            }
            #endregion
        }

        public class MoebelInfoUpdater : IExternalEventHandler
        {
            #region Event Handler für Möbel verändern
            public void Execute(UIApplication app)
            {
                update(_demoForm.F1.F2._mob);
            }

            private static void update(Mobiliar _mob)
            {
                if (_mob != null)
                {
                    try
                    {
                        bool worked;
                        if (_mob.Identity != null)
                        {
                            FamilyInstance fi = (FamilyInstance)_doc.GetElement(_mob.Identity);
                            using (Transaction trans = new Transaction(_doc))
                            {
                                if (trans.Start("Change Furniture Parameters") == TransactionStatus.Started)
                                {
                                    fi.Name = _mob.Name;
                                    worked = fi.GetParameters("Länge").First().Set(_mob.Length);
                                    worked &= fi.GetParameters("Höhe").First().Set(_mob.Hoehe);
                                    worked &= fi.GetParameters("Tiefe").First().Set(_mob.Breit);
                                    worked &= fi.GetParameters("Raum").First().Set(_mob.Raumkennzeichen);
                                    worked &= fi.GetParameters("Mieter").First().Set(_mob.MitName);
                                    worked &= fi.GetParameters("Material").First().Set(_mob.Material);
                                    worked &= fi.GetParameters("Zustand").First().Set(_mob.Zustand);
                                    worked &= fi.GetParameters("MoebelKosten").First().Set(_mob.Wert);

                                    trans.Commit();
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        TaskDialog.Show("MöbelInfoUpdater", e.Message);
                    }
                }

                else
                {
                    TaskDialog.Show("MoebelInfoUpdater", "Please select a Moebel!");
                }
            }
            public string GetName()
            {
                return "Update Möbel Information";
            }
            #endregion
        }


        public class TischPlacer : IExternalEventHandler
        {
            #region Event Handler für Tischplce
            public void Execute(UIApplication app)
            {
                placeMob(_demoForm.F1._cpr);
            }

            private void placeMob(PlaceData clr)
            {
                XYZ locR = _ecd.Application.ActiveUIDocument.Selection.PickPoint("Pick a point to place Tisch.");
                RevitRoom rr = _doc.GetElement(clr.room.Identity) as RevitRoom;
                XYZ p = ((LocationPoint)rr.Location).Point;
                RevitRoom roomAtPoint = _doc.GetRoomAtPoint(p);
                if (roomAtPoint.UniqueId != rr.UniqueId)
                {
                    TaskDialog.Show("ERROR", "Punkt liegt nicht in ausgewählten Raum.");
                    return;
                }

                if (null != locR)
                {
                    using (Transaction trans = new Transaction(_doc))
                    {
                        if (trans.Start("PlaceFamily") == TransactionStatus.Started)
                        {
                            FamilyInstance fi = _doc.Create.NewFamilyInstance(locR,
                                GetFamilySymbolByName(BuiltInCategory.OST_Furniture, "1600 x 800 x 700")
                                , StructuralType.NonStructural);
                            clr.mobiliar.Identity = fi.UniqueId;
                            clr.mobiliar.Name = fi.Name;
                            fi.GetParameters("MoebelKosten").First().Set(clr.mobiliar.Wert);
                            fi.GetParameters("Zustand").First().Set(clr.mobiliar.Zustand);
                            fi.GetParameters("Material").First().Set(clr.mobiliar.Material);
                            fi.GetParameters("Mieter").First().Set(clr.mobiliar.MitName);
                            fi.GetParameters("Raum").First().Set(clr.mobiliar.Raumkennzeichen);
                            fi.GetParameters("Länge").First().Set(clr.mobiliar.Length);
                            fi.GetParameters("Höhe").First().Set(clr.mobiliar.Hoehe);
                            fi.GetParameters("Tiefe").First().Set(clr.mobiliar.Breit);
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
                return "TischPlatzierer";

            }
            #endregion
        }
        #endregion
    }
}
