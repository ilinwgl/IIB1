using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace IIB1_Demonstrator_ClassLibrary.Classes
{
    [Serializable]
    public class Building
    {
        private String name;
        private String adress;
        private BindingList<Floor> floors;

        public Building()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="adress"></param>
        /// <param name="floors"></param>
        public Building(string name, string adress, BindingList<Floor> floors)
        {
            this.Name = name;
            this.Adress = adress;
            this.Floors = floors;
        }

        public string Name { get => name; set => name = value; }
        public string Adress { get => adress; set => adress = value; }
        public BindingList<Floor> Floors { get => floors; set => floors = value; }
    }
}
