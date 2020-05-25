using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using ClassFloor = IIB1_Gruppe31_Klassen.Floor;
using ClassRaum = IIB1_Gruppe31_Klassen.Raum;
using ClassMobiliar = IIB1_Gruppe31_Klassen.Mobiliar;
using IIB1_Gruppe31_Klassen;
using Autodesk.Revit.UI;
using System.ComponentModel;
using RevitRoom = Autodesk.Revit.DB.Architecture.Room;

namespace IIB1_HUE2_Gruppe31_RevitAddin
{
    class IIB1_Gruppe31_Util
    {
        private static Document _doc = null;

        public static Document Doc
        {
            set
            {
                _doc = value;
            }
        }

        #region bekommen die Building
        public static Building parseBuilding()
        {
            ProjectInfo pi = _doc.ProjectInformation;
            Building building = new Building(pi.Name, pi.Address, new BindingList<ClassFloor>());
            building.Floors = getFloors();
            return building;            
        }
        #endregion

        #region bekommen die Geschosse in der Building
        public static BindingList<ClassFloor> getFloors()
        {          
            FilteredElementCollector collector = new FilteredElementCollector(_doc);
            ICollection<Element> floors = collector.OfClass(typeof(Level)).ToElements();
            BindingList<ClassFloor> cfls = new BindingList<ClassFloor>();
            foreach (Element fl in floors)
            {
                ClassFloor cfl = parseFloor((Level)fl);
                cfl.Raums = getRooms((Level)fl);

                if (cfl.Raums.Count != 0)
                {
                    cfls.Add(cfl);
                }
            }
            return cfls;
        }

        public static ClassFloor parseFloor(Level floor)
        {
            ClassFloor cfl = new ClassFloor(floor.Name, new BindingList<ClassRaum>());
            cfl.Kennzeichen = floor.Id.ToString();
            return cfl;
        }
        #endregion

        #region bekommen die Räume im Geschoss
        public static BindingList<ClassRaum> getRooms(Level floor)
        {

            IEnumerable<Element> Roomsbylevel_filcol = new FilteredElementCollector(_doc) //search only in this level
            .OfClass(typeof(SpatialElement)).Where(room => room.GetType() == typeof(Autodesk.Revit.DB.Architecture.Room))  //get all rooms
            .Cast<SpatialElement>()  //cast results to SpatialElements
            .Where(o => o.LevelId == floor.Id); //search by the above mentioned Level

            BindingList<ClassRaum> crooms = new BindingList<ClassRaum>();
            foreach (SpatialElement r in Roomsbylevel_filcol)
            {
                ClassRaum croom = parseRoom((RevitRoom)r);

                if (croom != null)
                {
                    crooms.Add(croom);
                }
            }
            return crooms;
        }

        public static ClassRaum parseRoom(RevitRoom room)
        {
            Raum raum = new ClassRaum();
            raum.Identity = room.UniqueId;
            raum.Name = room.Name;
            raum.Flaechen = squarefeetToMeter(room.Area);
            string roomtyp = room.GetParameters("Nutzungsgruppe DIN 277-2")[0].AsString();
            raum.Bereich = room.GetParameters("Bereich")[0].AsString();
            raum.Besitzer = room.GetParameters("Besitzer")[0].AsString();
            raum.Umfang = room.GetParameters("Umfang")[0].AsDouble();
            raum.Mieter = room.GetParameters("Mieter")[0].AsString();
            raum.Miete = room.GetParameters("Miete")[0].AsDouble();
            raum.AnzahlArbeitsplaetze = room.GetParameters("Arbeitsplätze")[0].AsInteger();
            raum.AnzahlSitzplaetze = room.GetParameters("Sitzplätze")[0].AsInteger();
            raum.AnzahlAutomaten = room.GetParameters("Automat")[0].AsInteger();
            string v = room.GetParameters("Mieten")[0].AsString();
            if (v == "Ja")
            {
                raum.Vermieten = true;
            }
            else { raum.Vermieten = false; }

                List<Element> furniture = GetFurniture(room);
                BindingList<ClassMobiliar> moebel = new BindingList<ClassMobiliar>();

            foreach (Element e in furniture)
            {
                if (e.Name.StartsWith("1600"))
                {
                    ClassMobiliar mobiliar = new ClassMobiliar();
                    mobiliar.Identity = e.UniqueId;
                    mobiliar.Name = "Tisch " + e.Name + " " + e.Id;
                    mobiliar.Wert = e.GetParameters("MoebelKosten")[0].AsDouble();
                    mobiliar.Zustand = e.GetParameters("Zustand")[0].AsString();
                    mobiliar.MitName = room.GetParameters("Mieter")[0].AsString();
                    mobiliar.Length = e.GetParameters("Länge")[0].AsDouble();
                    mobiliar.Breit = e.GetParameters("Tiefe")[0].AsDouble();
                    mobiliar.Hoehe = e.GetParameters("Höhe")[0].AsDouble();
                    mobiliar.Material = e.GetParameters("Material")[0].AsString();
                    mobiliar.Raumkennzeichen = room.Name;

                    ClassMobiliar m = new Tisch(mobiliar);
                    m.Identity = e.UniqueId;
                    moebel.Add(m);
                }
                raum.Mobiliars = moebel;
            }


            if (roomtyp == "2-Büroarbeit")
            {
                Buero buero = new Buero(raum);
                return buero;
            }
            else if (roomtyp == "9-Verkehrserschl./sicherung")
            {
                Flur flur = new Flur(raum);
                return flur;
            }
            else if (roomtyp == "4-Lagern/Verteilen/Verkaufen")
            {
                Lagern lagern = new Lagern(raum);
                return lagern;
            }
            else if (roomtyp == "1-Wohnen und Aufenthalt")
            {
                Wohnenraum wohnenraum = new Wohnenraum(raum);
                return wohnenraum;
            }
            else if (roomtyp == "3-Produktion/Hand-Maschinenarbeit/Experiment")
            {
                Ruheraum ruheraum = new Ruheraum(raum);
                return ruheraum;
            }
            else if (roomtyp == "7-Sonstige Nutzflächen")
            {
                Sanitaerraum sanitaerraum = new Sanitaerraum(raum);
                return sanitaerraum;
            }
            else if (roomtyp == "8-Technische Anlagen")
            {
                Technischraum technischraum = new Technischraum(raum);
                return technischraum;
            }
            return null;
        }

        public static double squarefeetToMeter(double squarefeet)
        {
            double quadratmeter = (squarefeet / 10.7639);
            return Math.Round(quadratmeter, 2);
        }
        #endregion

        #region Methode für Möbelbekommen
        public static List<Element> GetFurniture(RevitRoom room)
        {
            BoundingBoxXYZ bb = room.get_BoundingBox(null);

            Outline outline = new Outline(bb.Min, bb.Max);

            BoundingBoxIntersectsFilter filter
              = new BoundingBoxIntersectsFilter(outline);

            Document doc = room.Document;

            BuiltInCategory[] bics = new BuiltInCategory[] {
                BuiltInCategory.OST_Furniture,
                BuiltInCategory.OST_GenericModel,
                BuiltInCategory.OST_SpecialityEquipment
            };

            LogicalOrFilter categoryFilter
                = new LogicalOrFilter(bics
                .Select<BuiltInCategory, ElementFilter>(
                bic => new ElementCategoryFilter(bic))
                .ToList<ElementFilter>());

            FilteredElementCollector collector
              = new FilteredElementCollector(doc)
                .WhereElementIsNotElementType()
                .WhereElementIsViewIndependent()
                .WherePasses(filter)
                .WherePasses(categoryFilter)
                .OfClass(typeof(FamilyInstance));


            int roomid = room.Id.IntegerValue;

            List<Element> a = new List<Element>();

            foreach (FamilyInstance fi in collector)
            {
                if (null != fi.Room 
                    && fi.Room.Id.IntegerValue.Equals(roomid))
                {
                    a.Add(fi);
                }
            }
            return a;
        }
        #endregion
    }
}


