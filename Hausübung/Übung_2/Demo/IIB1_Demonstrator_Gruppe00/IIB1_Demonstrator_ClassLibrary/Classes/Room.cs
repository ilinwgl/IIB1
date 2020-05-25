using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace IIB1_Demonstrator_ClassLibrary.Classes
{
    [Serializable]
    /// <summary>
    /// super class for all room typs
    /// </summary>
    public class Room
    {
        #region Fields and Properties
        // fields
        private string identity;
        private string name;      
        private double area;

        // Properties
        public string Name { get => name; set => name = value; }
        public double Area { get => area; set => area = value; }        
        public string Identity { get => identity; set => identity = value; }
        #endregion

        #region constructors
        /// <summary>
        /// Standard Constructor
        /// </summary>
        public Room()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="room"></param>
        public Room(Room room)
        {
            this.Identity = room.Identity;
            this.Name = room.Name;           
            this.Area = room.Area;
            
        }
        public Room (string name, double area)
        {            
            this.Name = name;          
            this.Area = area;
        }

        public Room ( string identity, string name, double area )
        {
            this.Identity = identity;
            this.Name = name;
            this.Area = area;
        }
        #endregion
    }
}
