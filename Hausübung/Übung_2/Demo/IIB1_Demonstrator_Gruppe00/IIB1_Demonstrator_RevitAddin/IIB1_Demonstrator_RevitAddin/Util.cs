using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using ClassFloor = IIB1_Demonstrator_ClassLibrary.Classes.Floor;
using ClassRoom = IIB1_Demonstrator_ClassLibrary.Classes.Room;
using IIB1_Demonstrator_ClassLibrary.Classes;
using Autodesk.Revit.UI;
using System.ComponentModel;
using RevitRoom = Autodesk.Revit.DB.Architecture.Room;

namespace IIB1_Demonstrator_RevitAddin
{
    public class Util
    {
        #region Attribute
        private static Document _doc = null;

        public static Document Doc
        {
            set
            {
                _doc = value;
            }
        }
        #endregion

        public static Building parseBuilding()
        {
            ProjectInfo pi = _doc.ProjectInformation;
            Building building = new Building(pi.Name, pi.Address, new BindingList<ClassFloor>());
            building.Floors = getFloors();           
            return building;
        }
    
        public static BindingList<ClassFloor> getFloors()
        {
            FilteredElementCollector collector = new FilteredElementCollector(_doc);
            ICollection<Element> floors = collector.OfClass(typeof(Level)).ToElements();
            BindingList<ClassFloor> cfls = new BindingList<ClassFloor>();
            foreach (Element fl in floors)
            {
                ClassFloor cfl = parseFloor((Level)fl);
                cfl.Rooms = getRooms((Level)fl);
                
                if (cfl.Rooms.Count != 0)
                {
                    cfls.Add(cfl);
                }
            }
            return cfls;
        }

        public static ClassFloor parseFloor(Level floor)
        {
            ClassFloor cfl = new ClassFloor(floor.Name, new BindingList<ClassRoom>());
            cfl.Identity = floor.Id.ToString();
            return cfl;
        }

        public static BindingList<ClassRoom> getRooms(Level floor)
        {
            
            IEnumerable<Element> Roomsbylevel_filcol = new FilteredElementCollector(_doc) //search only in this level
            .OfClass(typeof(SpatialElement)).Where(room => room.GetType() == typeof(Autodesk.Revit.DB.Architecture.Room))  //get all rooms
            .Cast<SpatialElement>()  //cast results to SpatialElements
            .Where(o => o.LevelId == floor.Id); //search by the above mentioned Level

            BindingList<ClassRoom> crooms = new BindingList<ClassRoom>(); 
            foreach (SpatialElement r in Roomsbylevel_filcol)
            {
                ClassRoom croom = parseRoom((RevitRoom)r);
                if (croom != null)
                {
                    crooms.Add(croom);
                }
            }
            return crooms;
        }

        public static ClassRoom parseRoom(RevitRoom room)
        {                     
            double area = squarefeetToMeter(room.Area);
            string roomtyp = room.GetParameters("Nutzungsgruppe DIN 277-2")[0].AsString();

            if (roomtyp == "2-Büroarbeit")
            {
                Office office = new Office(room.UniqueId,room.Name, area);
                return office;
            }
            else if (roomtyp == "1-Wohnen und Aufenthalt")
            {
                Livingroom live = new Livingroom(room.UniqueId, room.Name, area);
                return live;
            }
            return null;
        }

        public static double squarefeetToMeter(double squarefeet)
        {
            double quadratmeter = (squarefeet / 10.7639);
            return Math.Round(quadratmeter, 2);
        }
    }
}
