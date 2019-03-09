using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIB1_HUE1_AUF1
{
    public class Gebaeude
    {
        private string name;
        private string adress; 
        private List<Geschoss> geschoesse = new List<Geschoss>(); 

        public string Name { get => name; set => name = value; }
        public string Adress { get => adress; set => adress = value; }
        public List<Geschoss> Geschoesse { get => geschoesse; set => geschoesse = value; }

        public Gebaeude (string name, string adress, List<Geschoss> geschosses)
        {
            this.Name = name;
            this.Adress = adress;
            this.Geschoesse = geschoesse;
        }
    }
}
