using IIB1_HUE1_Gruppe31;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region instanziieren
        Bereich be = new Bereich();
        Besitzer besitzer = new Besitzer();
        Mieter mieter = new Mieter();
        static Buero buero = new Buero();
        Flur flur = new Flur();
        Lagern lagern = new Lagern();
        Sanitaerraum sanitaerraum = new Sanitaerraum();
        Seminarraum seminarraum = new Seminarraum();
        Ruheraum ruheraum = new Ruheraum();
        Stuhl stuhl = new Stuhl();
        Tisch tisch = new Tisch();
        Schrank schrank = new Schrank();


        //erstellen Liste 
        List<Mieter> allMieters = new List<Mieter>();
        List<Besitzer> allBesitzers = new List<Besitzer>();
        List<Raum> allRaum = new List<Raum>();
        List<Mobiliar> allMobiliar = new List<Mobiliar>();
        List<Buero> allBuero = new List<Buero>();
        List<Flur> allFlur = new List<Flur>();
        List<Lagern> allLagern = new List<Lagern>();
        List<Sanitaerraum> allSanitaerraum = new List<Sanitaerraum>();
        List<Seminarraum> allSeminarraum = new List<Seminarraum>();
        List<Ruheraum> allRuheraum = new List<Ruheraum>();
        List<Stuhl> allStuhl = new List<Stuhl>();
        List<Tisch> allTisch = new List<Tisch>();
        List<Schrank> allSchrank = new List<Schrank>();

        string[] mob = new string[] { "Stuhl", "Tisch", "Schrank" };
        string[] ver = new string[] { "Ja", "Nein" };
        string[] BeMi = new string[] { "Besitzer", "Mieter" };
        string[] Zust = new string[] { "defekt", "beschädigt", "intakt" };
        string[] nut = new string[] { "Büroarbeit : Büro", "Lagern, Verteilen und Verkaufen : Lagern", "Bildung, Unterricht und Kultur : Seminarraum", "Sonstige Benutzung : Flur", "Sonstige Benutzung : Sanitärraum", "Sonstige Benutzung : Ruheraum" };

#endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Load
            comboBoxBereich.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNutzung.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxVermieten.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMobiliar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMieter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMobiliarZustand.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBeMi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRaumBesitzer.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRaumMieter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMobiliarRaum.DropDownStyle = ComboBoxStyle.DropDownList;

            //Bereich in combiBoxBereich hinzufügen            
            for (int i = 0; i < be.Anteil.Length; i++)
            {
                comboBoxBereich.Items.Add(be.Anteil[i]);
            }

            //vermieten in comboBoxVermieten hinzufügen
            for (int i = 0; i < ver.Length; i++)
            {
                comboBoxVermieten.Items.Add(ver[i]);
            }

            //Mobiliar in comboBoxMobiliar hinzufügen            
            for (int i = 0; i < mob.Length; i++)
            {
                comboBoxMobiliar.Items.Add(mob[i]);
            }

            //Besitzer und Mieter in comboBoxBeMi hinzufügen
            for (int i = 0; i < BeMi.Length; i++)
            {
                comboBoxBeMi.Items.Add(BeMi[i]);
            }

            //Zustand der Mobiliar in comboBoxMobiliarZustand hinzufügen
            for (int i = 0; i < Zust.Length; i++)
            {
                comboBoxMobiliarZustand.Items.Add(Zust[i]);
            }
#endregion
        }

        #region Methode für Raum
        public void distinctRaum()
        {
            #region löschen die gleiche Item in Raum
            try
            {
                int m = int.Parse(textBoxRaumKennzeichen.Text);
                string a = comboBoxBereich.SelectedItem.ToString();
                string b = comboBoxNutzung.SelectedItem.ToString();

                //füllen listBoxRaum
                switch (a)
                {
                    case "Bürobereich":
                        {
                            foreach (Buero bu in allBuero)
                            {
                                if (bu.Kennzeichen == m)
                                {
                                    allBuero.Remove(bu);
                                }
                            }
                        }
                        break;
                    case "Lagernbereich":
                        {
                            foreach (Lagern la in allLagern)
                            {
                                if (la.Kennzeichen == m)
                                {
                                    allLagern.Remove(la);
                                }
                            }
                        }
                        break;
                    case "Gemeinschaftsbereich":
                        {
                            switch (b)
                            {
                                case "Bildung, Unterricht und Kultur : Seminarraum":
                                    {
                                        foreach (Seminarraum se in allSeminarraum)
                                        {
                                            if (se.Kennzeichen == m)
                                            {
                                                allSeminarraum.Remove(se);
                                            }
                                        }
                                    }
                                    break;
                                case "Sonstige Benutzung : Sanitärraum":
                                    {
                                        foreach (Sanitaerraum sa in allSanitaerraum)
                                        {
                                            if (sa.Kennzeichen == m)
                                            {
                                                allSanitaerraum.Remove(sa);
                                            }
                                        }
                                    }
                                    break;
                                case "Sonstige Benutzung : Flur":
                                    {
                                        foreach (Flur fl in allFlur)
                                        {
                                            if (fl.Kennzeichen == m)
                                            {
                                                allFlur.Remove(fl);
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        break;
                    case "Ruhezone":
                        {
                            foreach (Ruheraum ru in allRuheraum)
                            {
                                if (ru.Kennzeichen == m)
                                {
                                    allRuheraum.Remove(ru);
                                }
                            }
                        }
                        break;
                }
            }
            catch { };
        #endregion
        }

        public void getallBuero()
        {
            #region geben die Daten für Büro
            textBoxRaumArbeitsplätze.ReadOnly = false;
            textBoxRaumSitzplätze.ReadOnly = false;
            textBoxRaumAutomaten.ReadOnly = false;

            Buero bu = new Buero();
            bu.Kennzeichen = int.Parse(textBoxRaumKennzeichen.Text);
            bu.Bereich = comboBoxBereich.SelectedItem.ToString();
            bu.Floor = int.Parse(textBoxRaumGeschoss.Text);
            bu.Length = Convert.ToDouble(textBoxRaumLength.Text);
            bu.Breit = Convert.ToDouble(textBoxRaumBreite.Text);
            bu.Flaechen = bu.getFlaeche(bu.Length, bu.Breit);
            bu.Miete = Convert.ToDouble(textBoxRaumMiete.Text);
            bu.AnzahlArbeitsplaetze = int.Parse(textBoxRaumArbeitsplätze.Text);
            bu.AnzahlSitzplaetze = int.Parse(textBoxRaumSitzplätze.Text);
            bu.AnzahlAutomaten = int.Parse(textBoxRaumAutomaten.Text);

            if (comboBoxRaumBesitzer.SelectedItem == null)
            {
                bu.Besitzer = null;
            }
            else
            {
                bu.Besitzer = comboBoxRaumBesitzer.SelectedItem.ToString();
            }

            if (comboBoxVermieten.SelectedIndex == 0)
            {
                bu.Vermieten = true;
                bu.Mieter = comboBoxRaumMieter.SelectedItem.ToString();
            }
            else
            {
                bu.Vermieten = false;
                bu.Mieter = null;
            }

            distinctRaum();
            allBuero.Add(bu);
#endregion
        }

        public void getallLagern()
        {
            #region geben die Daten für Lagern
            //Lagern haben keine Arbeitsplätze und Sitzplätze
            textBoxRaumArbeitsplätze.ReadOnly = true;
            textBoxRaumSitzplätze.ReadOnly = true;
            textBoxRaumAutomaten.ReadOnly = false;

            Lagern la = new Lagern();
            la.Kennzeichen = int.Parse(textBoxRaumKennzeichen.Text);
            la.Bereich = comboBoxBereich.SelectedItem.ToString();
            la.Floor = int.Parse(textBoxRaumGeschoss.Text);
            la.Length = Convert.ToDouble(textBoxRaumLength.Text);
            la.Breit = Convert.ToDouble(textBoxRaumBreite.Text);
            la.Flaechen = la.getFlaeche(la.Length, la.Breit);
            la.Miete = Convert.ToDouble(textBoxRaumMiete.Text);
            la.AnzahlAutomaten = int.Parse(textBoxRaumAutomaten.Text);

            if (comboBoxRaumBesitzer.SelectedItem == null)
            {
                la.Besitzer = null;
            }
            else
            {
                la.Besitzer = comboBoxRaumBesitzer.SelectedItem.ToString();
            }

            if (comboBoxVermieten.SelectedIndex == 0)
            {
                la.Vermieten = true;
                la.Mieter = comboBoxRaumMieter.SelectedItem.ToString();
            }
            else
            {
                la.Vermieten = false;
                la.Mieter = null;
            }

            distinctRaum();
            allLagern.Add(la);
#endregion
        }
       
        public void getallFlur()
        {
            #region geben die Daten für Flur
            //Flur haben keine Arbeitsplätze und Sitzplätze
            textBoxRaumArbeitsplätze.ReadOnly = true;
            textBoxRaumSitzplätze.ReadOnly = true;
            textBoxRaumAutomaten.ReadOnly = false;

            Flur fl = new Flur();
            fl.Kennzeichen = int.Parse(textBoxRaumKennzeichen.Text);
            fl.Bereich = comboBoxBereich.SelectedItem.ToString();
            fl.Floor = int.Parse(textBoxRaumGeschoss.Text);
            fl.Length = Convert.ToDouble(textBoxRaumLength.Text);
            fl.Breit = Convert.ToDouble(textBoxRaumBreite.Text);
            fl.Flaechen = fl.getFlaeche(fl.Length, fl.Breit);
            fl.Miete = Convert.ToDouble(textBoxRaumMiete.Text);
            fl.AnzahlAutomaten = int.Parse(textBoxRaumAutomaten.Text);

            if (comboBoxRaumBesitzer.SelectedItem == null)
            {
                fl.Besitzer = null;
            }
            else
            {
                fl.Besitzer = comboBoxRaumBesitzer.SelectedItem.ToString();
            }

            if (comboBoxVermieten.SelectedIndex == 0)
            {
                fl.Vermieten = true;
                fl.Mieter = comboBoxRaumMieter.SelectedItem.ToString();
            }
            else
            {
                fl.Vermieten = false;
                fl.Mieter = null;
            }

            distinctRaum();
            allFlur.Add(fl);
#endregion
        }

        public void getallSanitaerraum()
        {
            #region geben die Daten für Sanitaerraum
            //Sanitaerraum haben keine Arbeitsplätze, Sitzplätze und Automaten
            textBoxRaumArbeitsplätze.ReadOnly = true;
            textBoxRaumSitzplätze.ReadOnly = true;
            textBoxRaumAutomaten.ReadOnly = true;

            Sanitaerraum sa = new Sanitaerraum();
            sa.Kennzeichen = int.Parse(textBoxRaumKennzeichen.Text);
            sa.Bereich = comboBoxBereich.SelectedItem.ToString();
            sa.Floor = int.Parse(textBoxRaumGeschoss.Text);
            sa.Length = Convert.ToDouble(textBoxRaumLength.Text);
            sa.Breit = Convert.ToDouble(textBoxRaumBreite.Text);
            sa.Flaechen = sa.getFlaeche(sa.Length, sa.Breit);
            sa.Miete = Convert.ToDouble(textBoxRaumMiete.Text);

            if (comboBoxRaumBesitzer.SelectedItem == null)
            {
                sa.Besitzer = null;
            }
            else
            {
                sa.Besitzer = comboBoxRaumBesitzer.SelectedItem.ToString();
            }

            if (comboBoxVermieten.SelectedIndex == 0)
            {
                sa.Vermieten = true;
                sa.Mieter = comboBoxRaumMieter.SelectedItem.ToString();
            }
            else
            {
                sa.Vermieten = false;
                sa.Mieter = null;
            }

            distinctRaum();
            allSanitaerraum.Add(sa);
#endregion
        }
      
        public void getallSeminarraum()
        {
            #region  geben die Daten für Seminarraum
            textBoxRaumArbeitsplätze.ReadOnly = false;
            textBoxRaumSitzplätze.ReadOnly = false;
            textBoxRaumAutomaten.ReadOnly = false;

            Seminarraum se = new Seminarraum();
            se.Kennzeichen = int.Parse(textBoxRaumKennzeichen.Text);
            se.Bereich = comboBoxBereich.SelectedItem.ToString();
            se.Floor = int.Parse(textBoxRaumGeschoss.Text);
            se.Length = Convert.ToDouble(textBoxRaumLength.Text);
            se.Breit = Convert.ToDouble(textBoxRaumBreite.Text);
            se.Flaechen = se.getFlaeche(se.Length, se.Breit);
            se.Miete = Convert.ToDouble(textBoxRaumMiete.Text);
            se.AnzahlArbeitsplaetze = int.Parse(textBoxRaumArbeitsplätze.Text);
            se.AnzahlSitzplaetze = int.Parse(textBoxRaumSitzplätze.Text);
            se.AnzahlAutomaten = int.Parse(textBoxRaumAutomaten.Text);

            if (comboBoxRaumBesitzer.SelectedItem == null)
            {
                se.Besitzer = null;
            }
            else
            {
                se.Besitzer = comboBoxRaumBesitzer.SelectedItem.ToString();
            }

            if (comboBoxVermieten.SelectedIndex == 0)
            {
                se.Vermieten = true;
                se.Mieter = comboBoxRaumMieter.SelectedItem.ToString();
            }
            else
            {
                se.Vermieten = false;
                se.Mieter = null;
            }

            distinctRaum();
            allSeminarraum.Add(se);
#endregion
        }
       
        public void getallRuheraum()
        {
            #region geben die Daten für Ruheraum
            //Ruheräume haben keine Arbeitsplätze
            textBoxRaumArbeitsplätze.ReadOnly = true;
            textBoxRaumSitzplätze.ReadOnly = false;
            textBoxRaumAutomaten.ReadOnly = false;

            Ruheraum ru = new Ruheraum();
            ru.Kennzeichen = int.Parse(textBoxRaumKennzeichen.Text);
            ru.Bereich = comboBoxBereich.SelectedItem.ToString();
            ru.Floor = int.Parse(textBoxRaumGeschoss.Text);
            ru.Length = Convert.ToDouble(textBoxRaumLength.Text);
            ru.Breit = Convert.ToDouble(textBoxRaumBreite.Text);
            ru.Flaechen = ru.getFlaeche(ru.Length, ru.Breit);
            ru.Miete = Convert.ToDouble(textBoxRaumMiete.Text);
            ru.AnzahlSitzplaetze = int.Parse(textBoxRaumSitzplätze.Text);
            ru.AnzahlAutomaten = int.Parse(textBoxRaumAutomaten.Text);

            if (comboBoxRaumBesitzer.SelectedItem == null)
            {
                ru.Besitzer = null;
            }
            else
            {
                ru.Besitzer = comboBoxRaumBesitzer.SelectedItem.ToString();
            }

            if (comboBoxVermieten.SelectedIndex == 0)
            {
                ru.Vermieten = true;
                ru.Mieter = comboBoxRaumMieter.SelectedItem.ToString();
            }
            else
            {
                ru.Vermieten = false;
                ru.Mieter = null;
            }

            distinctRaum();
            allRuheraum.Add(ru);
#endregion
        }

        public void getallRaum()
        {
            allRaum.Clear();
            foreach(Buero bu in allBuero)
            {
                allRaum.Add(bu);
            }
            foreach (Lagern la in allLagern)
            {
                allRaum.Add(la);
            }
            foreach (Flur fl in allFlur)
            {
                allRaum.Add(fl);
            }
            foreach (Seminarraum se in allSeminarraum)
            {
                allRaum.Add(se);
            }
            foreach (Sanitaerraum sa in allSanitaerraum)
            {
                allRaum.Add(sa);
            }
            foreach (Ruheraum ru in allRuheraum)
            {
                allRaum.Add(ru);
            }
        }

       public void getBesitzer()
        {
            #region bekommen Raum Besitzer
            getallRaum();
            try
            {
                foreach (Besitzer b in allBesitzers)
                {
                    for (int i = 0; i < allRaum.Count; i++)
                    {
                        if (b.getName() == allRaum[i].Besitzer)
                        {
                            string x = allRaum[i].getName();
                            b.Raumkennzeichen = x;
                        }
                    }
                }
            }
            catch { }
#endregion
        }

        public void getMieter()
        {
            #region bekommen Raum Mieter
            getallRaum();
            try
            {
                foreach (Mieter mi in allMieters)
                {
                    for (int i = 0; i < allRaum.Count; i++)
                    {
                        if (mi.getName() == allRaum[i].Mieter)
                        {
                            mi.Raumkennzeichen = allRaum[i].getName();
                        }
                    }
                }
            }
            catch { }
#endregion
        }

        public void addRaum()
        {
            #region listBoxRaum füllen
            //füllen die Raumlist
            string a = comboBoxBereich.SelectedItem.ToString();
            string b = comboBoxNutzung.SelectedItem.ToString();

            //füllen listBoxRaum
            switch (a)
            {
                case "Bürobereich":
                    {
                        getallBuero();
                        foreach (Buero bu in allBuero)
                        {
                            listBoxRaum.Items.Add(bu);
                        }
                    }
                    break;

                case "Lagernbereich":
                    {
                        getallLagern();
                        foreach (Lagern la in allLagern)
                        {
                            listBoxRaum.Items.Add(la);
                        }
                    }
                    break;

                case "Gemeinschaftsbereich":
                    {
                        switch (b)
                        {
                            case "Bildung, Unterricht und Kultur : Seminarraum":
                                {
                                    getallSeminarraum();
                                    foreach (Seminarraum se in allSeminarraum)
                                    {
                                        listBoxRaum.Items.Add(se);
                                    }
                                }
                                break;

                            case "Sonstige Benutzung : Sanitärraum":
                                {
                                    getallSanitaerraum();
                                    foreach (Sanitaerraum sa in allSanitaerraum)
                                    {
                                        listBoxRaum.Items.Add(sa);
                                    }
                                }
                                break;

                            case "Sonstige Benutzung : Flur":
                                {
                                    getallFlur();
                                    foreach (Flur fl in allFlur)
                                    {
                                        listBoxRaum.Items.Add(fl);
                                    }
                                }
                                break;
                        }
                    }
                    break;

                case "Ruhezone":
                    {
                        getallRuheraum();
                        foreach (Ruheraum ru in allRuheraum)
                        {
                            listBoxRaum.Items.Add(ru);
                        }
                    }
                    break;
            }
#endregion
        }

        public void removeRaum()
        {
            #region listBoxRaum löschen
            string a = comboBoxBereich.SelectedItem.ToString();
            string b = comboBoxNutzung.SelectedItem.ToString();

            switch (a)
            {
                case "Bürobereich":
                    {
                        for (int i = 0; i < allBuero.Count; i++)
                        {
                            if (buero.Equals(allBuero[i]))
                            {
                                allBuero.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;

                case "Lagernbereich":
                    {
                        for (int i = 0; i < allLagern.Count; i++)
                        {
                            if (lagern.Equals(allLagern[i]))
                            {
                                allLagern.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;

                case "Gemeinschaftsbereich":
                    {
                        switch (b)
                        {
                            case "Bildung, Unterricht und Kultur : Seminarraum":
                                {
                                    for (int i = 0; i < allSeminarraum.Count; i++)
                                    {
                                        if (seminarraum.Equals(allSeminarraum[i]))
                                        {
                                            allSeminarraum.RemoveAt(i);
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "Sonstige Benutzung : Sanitärraum":
                                {
                                    for (int i = 0; i < allSanitaerraum.Count; i++)
                                    {
                                        if (sanitaerraum.Equals(allSanitaerraum[i]))
                                        {
                                            allSanitaerraum.RemoveAt(i);
                                            break;
                                        }
                                    }
                                }
                                break;

                            case "Sonstige Benutzung : Flur":
                                {
                                    for (int i = 0; i < allFlur.Count; i++)
                                    {
                                        if (flur.Equals(allFlur[i]))
                                        {
                                            allFlur.RemoveAt(i);
                                            break;
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    break;

                case "Ruhezone":
                    {
                        for (int i = 0; i < allRuheraum.Count; i++)
                        {
                            if (ruheraum.Equals(allRuheraum[i]))
                            {
                                allRuheraum.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;
            }
         #endregion
        }

        public void auslesenRaum()
        {
            #region listBoxRaum auslesen
            clearRaumtext();

            string a = comboBoxBereich.SelectedItem.ToString();
            string b = comboBoxNutzung.SelectedItem.ToString();

            //Daten ablesen von listBoxRaum
            switch (a)
            {
                case "Bürobereich":
                    {
                        Buero bu = (Buero)listBoxRaum.SelectedItem;
                        buero = bu;
                        textBoxRaumKennzeichen.Text = bu.Kennzeichen.ToString();
                        textBoxRaumGeschoss.Text = bu.Floor.ToString();
                        textBoxRaumLength.Text = bu.Length.ToString();
                        textBoxRaumBreite.Text = bu.Breit.ToString();
                        labelFlächen.Text = bu.Flaechen.ToString();
                        textBoxRaumMiete.Text = bu.Miete.ToString();
                        textBoxRaumArbeitsplätze.Text = bu.AnzahlArbeitsplaetze.ToString();
                        textBoxRaumSitzplätze.Text = bu.AnzahlSitzplaetze.ToString();
                        textBoxRaumAutomaten.Text = bu.AnzahlAutomaten.ToString();
                        if (bu.Vermieten == true)
                        {
                            comboBoxVermieten.SelectedIndex = 0;
                            foreach (Mieter mi in allMieters)
                            {
                                if (bu.Mieter == mi.getName())
                                {
                                    int idx = allMieters.IndexOf(mi);
                                    comboBoxRaumMieter.SelectedIndex = idx;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            comboBoxVermieten.SelectedIndex = 1;
                            comboBoxRaumMieter.SelectedIndex = -1;
                        }

                        if (bu.Besitzer == null)
                        {
                            comboBoxRaumBesitzer.SelectedItem = null;
                        }
                        else
                        {
                            foreach (Besitzer be in allBesitzers)
                            {
                                if (bu.Besitzer == be.getName())
                                {
                                    int idx = allBesitzers.IndexOf(be);
                                    comboBoxRaumBesitzer.SelectedIndex = idx;
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case "Lagernbereich":
                    {
                        Lagern la = (Lagern)listBoxRaum.SelectedItem;
                        lagern = la;
                        textBoxRaumKennzeichen.Text = la.Kennzeichen.ToString();
                        textBoxRaumGeschoss.Text = la.Floor.ToString();
                        textBoxRaumLength.Text = la.Length.ToString();
                        textBoxRaumBreite.Text = la.Breit.ToString();
                        labelFlächen.Text = la.Flaechen.ToString();
                        textBoxRaumMiete.Text = la.Miete.ToString();
                        textBoxRaumAutomaten.Text = la.AnzahlAutomaten.ToString();
                        if (la.Vermieten == true)
                        {
                            comboBoxVermieten.SelectedIndex = 0;
                            foreach (Mieter mi in allMieters)
                            {
                                if (la.Mieter == mi.getName())
                                {
                                    int idx = allMieters.IndexOf(mi);
                                    comboBoxRaumMieter.SelectedIndex = idx;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            comboBoxVermieten.SelectedIndex = 1;
                            comboBoxRaumMieter.SelectedIndex = -1;
                        }

                        if (la.Besitzer == null)
                        {
                            comboBoxRaumBesitzer.SelectedItem = null;
                        }
                        else
                        {
                            foreach (Besitzer be in allBesitzers)
                            {
                                if (la.Besitzer == be.getName())
                                {
                                    int idx = allBesitzers.IndexOf(be);
                                    comboBoxRaumBesitzer.SelectedIndex = idx;
                                    break;
                                }
                            }
                        }
                    }
                    break;

                case "Gemeinschaftsbereich":
                    {
                        switch (b)
                        {
                            case "Bildung, Unterricht und Kultur : Seminarraum":
                                {
                                    Seminarraum se = (Seminarraum)listBoxRaum.SelectedItem;
                                    seminarraum = se;
                                    textBoxRaumKennzeichen.Text = se.Kennzeichen.ToString();
                                    textBoxRaumGeschoss.Text = se.Floor.ToString();
                                    textBoxRaumLength.Text = se.Length.ToString();
                                    textBoxRaumBreite.Text = se.Breit.ToString();
                                    labelFlächen.Text = se.Flaechen.ToString();
                                    textBoxRaumMiete.Text = se.Miete.ToString();
                                    textBoxRaumArbeitsplätze.Text = se.AnzahlArbeitsplaetze.ToString();
                                    textBoxRaumSitzplätze.Text = se.AnzahlSitzplaetze.ToString();
                                    textBoxRaumAutomaten.Text = se.AnzahlAutomaten.ToString();
                                    if (se.Vermieten == true)
                                    {
                                        comboBoxVermieten.SelectedIndex = 0;
                                        foreach (Mieter mi in allMieters)
                                        {
                                            if (se.Mieter == mi.getName())
                                            {
                                                int idx = allMieters.IndexOf(mi);
                                                comboBoxRaumMieter.SelectedIndex = idx;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        comboBoxVermieten.SelectedIndex = 1;
                                        comboBoxRaumMieter.SelectedIndex = -1;
                                    }

                                    if (se.Besitzer == null)
                                    {
                                        comboBoxRaumBesitzer.SelectedItem = null;
                                    }
                                    else
                                    {
                                        foreach (Besitzer be in allBesitzers)
                                        {
                                            if (se.Besitzer == be.getName())
                                            {
                                                int idx = allBesitzers.IndexOf(be);
                                                comboBoxRaumBesitzer.SelectedIndex = idx;
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;

                            case "Sonstige Benutzung : Sanitärraum":
                                {
                                    Sanitaerraum sa = (Sanitaerraum)listBoxRaum.SelectedItem;
                                    sanitaerraum = sa;
                                    textBoxRaumKennzeichen.Text = sa.Kennzeichen.ToString();
                                    textBoxRaumGeschoss.Text = sa.Floor.ToString();
                                    textBoxRaumLength.Text = sa.Length.ToString();
                                    textBoxRaumBreite.Text = sa.Breit.ToString();
                                    labelFlächen.Text = sa.Flaechen.ToString();
                                    textBoxRaumMiete.Text = sa.Miete.ToString();
                                    if (sa.Vermieten == true)
                                    {
                                        comboBoxVermieten.SelectedIndex = 0;
                                        foreach (Mieter mi in allMieters)
                                        {
                                            if (sa.Mieter == mi.getName())
                                            {
                                                int idx = allMieters.IndexOf(mi);
                                                comboBoxRaumMieter.SelectedIndex = idx;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        comboBoxVermieten.SelectedIndex = 1;
                                        comboBoxRaumMieter.SelectedIndex = -1;
                                    }

                                    if (sa.Besitzer == null)
                                    {
                                        comboBoxRaumBesitzer.SelectedItem = null;
                                    }
                                    else
                                    {
                                        foreach (Besitzer be in allBesitzers)
                                        {
                                            if (sa.Besitzer == be.getName())
                                            {
                                                int idx = allBesitzers.IndexOf(be);
                                                comboBoxRaumBesitzer.SelectedIndex = idx;
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;

                            case "Sonstige Benutzung : Flur":
                                {
                                    Flur fl = (Flur)listBoxRaum.SelectedItem;
                                    flur = fl;
                                    textBoxRaumKennzeichen.Text = fl.Kennzeichen.ToString();
                                    textBoxRaumGeschoss.Text = fl.Floor.ToString();
                                    textBoxRaumLength.Text = fl.Length.ToString();
                                    textBoxRaumBreite.Text = fl.Breit.ToString();
                                    labelFlächen.Text = fl.Flaechen.ToString();
                                    textBoxRaumMiete.Text = fl.Miete.ToString();
                                    textBoxRaumAutomaten.Text = fl.AnzahlAutomaten.ToString();
                                    if (fl.Vermieten == true)
                                    {
                                        comboBoxVermieten.SelectedIndex = 0;
                                        foreach (Mieter mi in allMieters)
                                        {
                                            if (fl.Mieter == mi.getName())
                                            {
                                                int idx = allMieters.IndexOf(mi);
                                                comboBoxRaumMieter.SelectedIndex = idx;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        comboBoxVermieten.SelectedIndex = 1;
                                        comboBoxRaumMieter.SelectedIndex = -1;
                                    }

                                    if (fl.Besitzer == null)
                                    {
                                        comboBoxRaumBesitzer.SelectedItem = null;
                                    }
                                    else
                                    {
                                        foreach (Besitzer be in allBesitzers)
                                        {
                                            if (fl.Besitzer == be.getName())
                                            {
                                                int idx = allBesitzers.IndexOf(be);
                                                comboBoxRaumBesitzer.SelectedIndex = idx;
                                                break;
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    break;

                case "Ruhezone":
                    {
                        Ruheraum ru = (Ruheraum)listBoxRaum.SelectedItem;
                        ruheraum = ru;
                        textBoxRaumKennzeichen.Text = ru.Kennzeichen.ToString();
                        textBoxRaumGeschoss.Text = ru.Floor.ToString();
                        textBoxRaumLength.Text = ru.Length.ToString();
                        textBoxRaumBreite.Text = ru.Breit.ToString();
                        labelFlächen.Text = ru.Flaechen.ToString();
                        textBoxRaumMiete.Text = ru.Miete.ToString();
                        textBoxRaumSitzplätze.Text = ru.AnzahlSitzplaetze.ToString();
                        textBoxRaumAutomaten.Text = ru.AnzahlAutomaten.ToString();
                        if (ru.Vermieten == true)
                        {
                            comboBoxVermieten.SelectedIndex = 0;
                            foreach (Mieter mi in allMieters)
                            {
                                if (ru.Mieter == mi.getName())
                                {
                                    int idx = allMieters.IndexOf(mi);
                                    comboBoxRaumMieter.SelectedIndex = idx;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            comboBoxVermieten.SelectedIndex = 1;
                            comboBoxRaumMieter.SelectedIndex = -1;
                        }

                        if (ru.Besitzer == null)
                        {
                            comboBoxRaumBesitzer.SelectedItem = null;
                        }
                        else
                        {
                            foreach (Besitzer be in allBesitzers)
                            {
                                if (ru.Besitzer == be.getName())
                                {
                                    int idx = allBesitzers.IndexOf(be);
                                    comboBoxRaumBesitzer.SelectedIndex = idx;
                                    break;
                                }
                            }
                        }
                    }
                    break;
            }
        #endregion
        }

        public void refreshRaum()
        {
            #region listBoxRaum aktualisieren
            //füllen die Raumlist
            string a = comboBoxBereich.SelectedItem.ToString();
            string b = comboBoxNutzung.SelectedItem.ToString();
            
            //füllen listBoxRaum
            switch (a)
            {
                case "Bürobereich":
                    {
                        textBoxRaumArbeitsplätze.ReadOnly = false;
                        textBoxRaumSitzplätze.ReadOnly = false;
                        textBoxRaumAutomaten.ReadOnly = false;
                        foreach (Buero bu in allBuero)
                        {
                            listBoxRaum.Items.Add(bu);
                        }
                    }
                    break;
              
                case "Lagernbereich":
                    {
                        textBoxRaumArbeitsplätze.ReadOnly = true;
                        textBoxRaumSitzplätze.ReadOnly = true;
                        textBoxRaumAutomaten.ReadOnly = false;

                        foreach (Lagern la in allLagern)
                        {
                            listBoxRaum.Items.Add(la);
                        }
                    }
                    break;

                case "Gemeinschaftsbereich":
                    {
                        switch (b)
                        {
                            case "Bildung, Unterricht und Kultur : Seminarraum":
                                {
                                    textBoxRaumArbeitsplätze.ReadOnly = false;
                                    textBoxRaumSitzplätze.ReadOnly = false;
                                    textBoxRaumAutomaten.ReadOnly = false;

                                    foreach (Seminarraum se in allSeminarraum)
                                    {
                                        listBoxRaum.Items.Add(se);
                                    }
                                }
                                break;

                            case "Sonstige Benutzung : Sanitärraum":
                                {
                                    textBoxRaumArbeitsplätze.ReadOnly = true;
                                    textBoxRaumSitzplätze.ReadOnly = true;
                                    textBoxRaumAutomaten.ReadOnly = true;

                                    foreach (Sanitaerraum sa in allSanitaerraum)
                                    {
                                        listBoxRaum.Items.Add(sa);
                                    }
                                }
                                break;

                            case "Sonstige Benutzung : Flur":
                                {
                                    textBoxRaumArbeitsplätze.ReadOnly = true;
                                    textBoxRaumSitzplätze.ReadOnly = true;
                                    textBoxRaumAutomaten.ReadOnly = false;

                                    foreach (Flur fl in allFlur)
                                    {
                                        listBoxRaum.Items.Add(fl);
                                    }
                                }
                                break;
                        }
                    }
                    break;

                case "Ruhezone":
                    {
                        textBoxRaumArbeitsplätze.ReadOnly = true;
                        textBoxRaumSitzplätze.ReadOnly = false;
                        textBoxRaumAutomaten.ReadOnly = false;
                        foreach (Ruheraum ru in allRuheraum)
                        {
                            listBoxRaum.Items.Add(ru);
                        }
                    }
                    break;
            }
          #endregion
        }

        public void clearRaumtext()
        {
            #region Clear textBox für Raum
            textBoxRaumKennzeichen.Clear();
            textBoxRaumLength.Clear();
            textBoxRaumBreite.Clear();
            textBoxRaumGeschoss.Clear();
            textBoxRaumMiete.Clear();
            textBoxRaumArbeitsplätze.Clear();
            textBoxRaumSitzplätze.Clear();
            textBoxRaumAutomaten.Clear();
            comboBoxVermieten.SelectedItem = null;
            labelFlächen.Text = null;
            comboBoxRaumBesitzer.SelectedIndex = -1;
            comboBoxRaumMieter.SelectedIndex = -1;
#endregion
        }

        public void getBereichGeroesse()
        {
            #region bekommen die Größe des Bereichs
            string a = comboBoxBereich.SelectedItem.ToString();
            string b = comboBoxNutzung.SelectedItem.ToString();

            //Daten ablesen von listBoxRaum
            switch (a)
            {
                case "Bürobereich":
                    {
                        foreach (Buero bu in allBuero)
                        {
                            be.getGroesse(bu);
                        }
                    }
                    break;

                case "Lagernbereich":
                    {
                        foreach (Lagern la in allLagern)
                        {
                            be.getGroesse(la);
                        }
                    }
                    break;

                case "Gemeinschaftsbereich":
                    {
                        switch (b)
                        {
                            case "Bildung, Unterricht und Kultur : Seminarraum":
                                {
                                    foreach (Seminarraum se in allSeminarraum)
                                    {
                                        be.getGroesse(se);
                                    }
                                }
                                break;

                            case "Sonstige Benutzung : Sanitärraum":
                                {
                                    foreach (Sanitaerraum sa in allSanitaerraum)
                                    {
                                        be.getGroesse(sa);
                                    }
                                }
                                break;

                            case "Sonstige Benutzung : Flur":
                                {
                                    foreach (Flur fl in allFlur)
                                    {
                                        be.getGroesse(fl);
                                    }
                                }
                                break;
                        }
                    }
                    break;

                case "Ruhezone":
                    {
                        foreach (Ruheraum ru in allRuheraum)
                        {
                            be.getGroesse(ru);
                        }
                    }
                    break;
            }
            label19.Text = be.Groesse.ToString();
            be.Groesse = 0;
#endregion
        }

        public List<string> getRaumMob(Raum raum)
        {
            #region get Mobiliar in einen Raum
            List<string> li = new List<string>();
            foreach (Mobiliar mo in allMobiliar)
            {
                string a = raum.getName();
                if (a == mo.Raumkennzeichen)
                {
                    string m = mo.getName();
                    raum.RaumMobiliar.Add(m);
                    li = raum.RaumMobiliar;
                }
            }
            return li;
#endregion
        }

        public void Raumserialisierung()
        {
            if (comboBoxBereich.SelectedItem == null || comboBoxNutzung.SelectedItem == null)
            {
                MessageBox.Show("Bereich und Nutzung wählen Zuerst!");
            }
            else
            {
                string a = comboBoxBereich.SelectedItem.ToString();
            string b = comboBoxNutzung.SelectedItem.ToString();

                switch (a)
                {
                    case "Bürobereich":
                        {
                            getallBuero();
                            if (allBuero.Count == 0)
                            {
                                MessageBox.Show("Speichern Zuerst!");
                            }
                            else
                            {
                                SaveFileDialog sfd = new SaveFileDialog();

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Buero bu in allBuero)
                                    {
                                        bu.speichern(sfd.FileName, allBuero);
                                    }
                                }
                            }
                        }
                        break;

                    case "Lagernbereich":
                        {
                            getallLagern();
                            if (allLagern.Count == 0)
                            {
                                MessageBox.Show("Speichern Zuerst!");
                            }
                            else
                            {
                                SaveFileDialog sfd = new SaveFileDialog();

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Lagern la in allLagern)
                                    {
                                        la.speichern(sfd.FileName, allLagern);
                                    }
                                }
                            }
                        }
                        break;

                    case "Gemeinschaftsbereich":
                        {
                            switch (b)
                            {
                                case "Bildung, Unterricht und Kultur : Seminarraum":
                                    {
                                        getallSeminarraum();
                                        if (allSeminarraum.Count == 0)
                                        {
                                            MessageBox.Show("Speichern Zuerst!");
                                        }
                                        else
                                        {
                                            SaveFileDialog sfd = new SaveFileDialog();

                                            if (sfd.ShowDialog() == DialogResult.OK)
                                            {
                                                foreach (Seminarraum se in allSeminarraum)
                                                {
                                                    se.speichern(sfd.FileName, allSeminarraum);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case "Sonstige Benutzung : Sanitärraum":
                                    {
                                        getallSanitaerraum();
                                        if (allSanitaerraum.Count == 0)
                                        {
                                            MessageBox.Show("Speichern Zuerst!");
                                        }
                                        else
                                        {
                                            SaveFileDialog sfd = new SaveFileDialog();

                                            if (sfd.ShowDialog() == DialogResult.OK)
                                            {
                                                foreach (Sanitaerraum sa in allSanitaerraum)
                                                {
                                                    sa.speichern(sfd.FileName, allSanitaerraum);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case "Sonstige Benutzung : Flur":
                                    {
                                        getallFlur();
                                        if (allFlur.Count == 0)
                                        {
                                            MessageBox.Show("Speichern Zuerst!");
                                        }
                                        else
                                        {
                                            SaveFileDialog sfd = new SaveFileDialog();

                                            if (sfd.ShowDialog() == DialogResult.OK)
                                            {
                                                foreach (Flur fl in allFlur)
                                                {
                                                    fl.speichern(sfd.FileName, allFlur);
                                                }
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        break;

                    case "Ruhezone":
                        {
                            getallRuheraum();
                            if (allRuheraum.Count == 0)
                            {
                                MessageBox.Show("Speichern Zuerst!");
                            }
                            else
                            {
                                SaveFileDialog sfd = new SaveFileDialog();

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Ruheraum ru in allRuheraum)
                                    {
                                        ru.speichern(sfd.FileName, allRuheraum);
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }

        public void Raumdeserialisierung()
        {
            if (comboBoxBereich.SelectedItem == null || comboBoxNutzung.SelectedItem == null)
            {
                MessageBox.Show("Bereich und Nutzung wählen Zuerst!");
            }
            else
            {
            string a = comboBoxBereich.SelectedItem.ToString();
            string b = comboBoxNutzung.SelectedItem.ToString();

                switch (a)
                {
                    case "Bürobereich":
                        {
                            listBoxRaum.Items.Clear();
                            OpenFileDialog ofdb = new OpenFileDialog();
                            if (ofdb.ShowDialog() == DialogResult.OK)
                            {
                                List<Buero> bu = new List<Buero>();
                                bu = Buero.laden(ofdb.FileName);
                                for (int i = 0; i < bu.Count; i++)
                                {
                                    listBoxRaum.Items.Add(bu[i]);
                                }
                            }
                        }
                        break;

                    case "Lagernbereich":
                        {
                            listBoxRaum.Items.Clear();
                            OpenFileDialog ofdl = new OpenFileDialog();
                            if (ofdl.ShowDialog() == DialogResult.OK)
                            {
                                List<Lagern> la = new List<Lagern>();
                                la = Lagern.laden(ofdl.FileName);
                                for (int i = 0; i < la.Count; i++)
                                {
                                    listBoxRaum.Items.Add(la[i]);
                                }
                            }
                        }
                        break;

                    case "Gemeinschaftsbereich":
                        {
                            switch (b)
                            {
                                case "Bildung, Unterricht und Kultur : Seminarraum":
                                    {
                                        listBoxRaum.Items.Clear();
                                        OpenFileDialog ofde = new OpenFileDialog();
                                        if (ofde.ShowDialog() == DialogResult.OK)
                                        {
                                            List<Seminarraum> se = new List<Seminarraum>();
                                            se = Seminarraum.laden(ofde.FileName);
                                            for (int i = 0; i < se.Count; i++)
                                            {
                                                listBoxRaum.Items.Add(se[i]);
                                            }
                                        }
                                    }
                                    break;

                                case "Sonstige Benutzung : Sanitärraum":
                                    {
                                        listBoxRaum.Items.Clear();
                                        OpenFileDialog ofda = new OpenFileDialog();
                                        if (ofda.ShowDialog() == DialogResult.OK)
                                        {
                                            List<Sanitaerraum> sa = new List<Sanitaerraum>();
                                            sa = Sanitaerraum.laden(ofda.FileName);
                                            for (int i = 0; i < sa.Count; i++)
                                            {
                                                listBoxRaum.Items.Add(sa[i]);
                                            }
                                        }
                                    }

                                    break;

                                case "Sonstige Benutzung : Flur":
                                    {
                                        listBoxRaum.Items.Clear();
                                        OpenFileDialog ofdf = new OpenFileDialog();
                                        if (ofdf.ShowDialog() == DialogResult.OK)
                                        {
                                            List<Flur> fl = new List<Flur>();
                                            fl = Flur.laden(ofdf.FileName);
                                            for (int i = 0; i < fl.Count; i++)
                                            {
                                                listBoxRaum.Items.Add(fl[i]);
                                            }
                                        }
                                    }
                                    break;
                            }
                        }
                        break;

                    case "Ruhezone":
                        {
                            listBoxRaum.Items.Clear();
                            OpenFileDialog ofdr = new OpenFileDialog();
                            if (ofdr.ShowDialog() == DialogResult.OK)
                            {
                                List<Ruheraum> ru = new List<Ruheraum>();
                                ru = Ruheraum.laden(ofdr.FileName);
                                for (int i = 0; i < ru.Count; i++)
                                {
                                    listBoxRaum.Items.Add(ru[i]);
                                }
                            }
                        }
                        break;
                }
            }
        }
#endregion

        #region Methode für Mobiliair
        public void distinctMobiliar()
        {
            #region löschen die gleiche Item in Mobilair
            try
            {
                int m = int.Parse(textBoxMobiliarKennzeichen.Text);
                string a = comboBoxMobiliar.SelectedItem.ToString();

                //füllen listBoxRaum
                switch (a)
                {
                    case "Stuhl":
                        {
                            foreach (Stuhl st in allStuhl)
                            {
                                if (st.Kennzeichen == m)
                                {
                                    allStuhl.Remove(st);
                                }
                            }
                        }
                        break;
                    case "Tisch":
                        {
                            foreach (Tisch ti in allTisch)
                            {
                                if (ti.Kennzeichen == m)
                                {
                                    allTisch.Remove(ti);
                                }
                            }
                        }
                        break;
                    case "Schrank":
                        {
                            foreach (Schrank sc in allSchrank)
                            {
                                if (sc.Kennzeichen == m)
                                {
                                    allSchrank.Remove(sc);
                                }
                            }
                        }
                        break;
                }
            }
            catch { };
#endregion
        }

        public void getallStuhl()
        {
            #region geben die Daten für Stuhl
            Stuhl st = new Stuhl();

            st.Kennzeichen = int.Parse(textBoxMobiliarKennzeichen.Text);
            st.Zustand = comboBoxMobiliarZustand.SelectedItem.ToString();
            st.Material = textBoxMobiliarMaterial.Text;
            st.Wert = Convert.ToDouble(textBoxMobiliarWert.Text);
            st.Raumkennzeichen = comboBoxMobiliarRaum.SelectedItem.ToString();
            st.Length = Convert.ToDouble(textBoxMobiliarLength.Text);
            st.Breit = Convert.ToDouble(textBoxMobiliarBreite.Text);
            st.Hoehe = Convert.ToDouble(textBoxMobiliarHöhe.Text);
            st.getFlaechen(st.Length, st.Breit);
            labelMobiliarFlächen.Text = st.Flaechen.ToString();
            if (comboBoxMieter.SelectedIndex != -1)
            {
                Mieter m = (Mieter)comboBoxMieter.SelectedItem;
                st.Mitkennzeichen = m.Kennzeichen;
            }
            else { st.Mitkennzeichen = 0; }

            distinctMobiliar();
            allStuhl.Add(st);
#endregion
        }

        public void getallTisch()
        {
            #region geben die Daten für Tisch
            Tisch ti = new Tisch();

            ti.Kennzeichen = int.Parse(textBoxMobiliarKennzeichen.Text);
            ti.Zustand = comboBoxMobiliarZustand.SelectedItem.ToString();
            ti.Material = textBoxMobiliarMaterial.Text;
            ti.Wert = Convert.ToDouble(textBoxMobiliarWert.Text);
            ti.Raumkennzeichen = comboBoxMobiliarRaum.SelectedItem.ToString();
            ti.Length = Convert.ToDouble(textBoxMobiliarLength.Text);
            ti.Breit = Convert.ToDouble(textBoxMobiliarBreite.Text);
            ti.Hoehe = Convert.ToDouble(textBoxMobiliarHöhe.Text);
            ti.getFlaechen(ti.Length, ti.Breit);
            labelMobiliarFlächen.Text = ti.Flaechen.ToString();
            if (comboBoxMieter.SelectedIndex != -1)
            {
                Mieter m = (Mieter)comboBoxMieter.SelectedItem;
                ti.Mitkennzeichen = m.Kennzeichen;
            }
            else { ti.Mitkennzeichen = 0; }

            distinctMobiliar();
            allTisch.Add(ti);
#endregion
        }

        public void getallSchrank()
        {
            #region geben die Daten für Schrank
            Schrank sc = new Schrank();

            sc.Kennzeichen = int.Parse(textBoxMobiliarKennzeichen.Text);
            sc.Zustand = comboBoxMobiliarZustand.SelectedItem.ToString();
            sc.Material = textBoxMobiliarMaterial.Text;
            sc.Wert = Convert.ToDouble(textBoxMobiliarWert.Text);
            sc.Raumkennzeichen = comboBoxMobiliarRaum.SelectedItem.ToString();
            sc.Length = Convert.ToDouble(textBoxMobiliarLength.Text);
            sc.Breit = Convert.ToDouble(textBoxMobiliarBreite.Text);
            sc.Hoehe = Convert.ToDouble(textBoxMobiliarHöhe.Text);
            sc.getFlaechen(sc.Length, sc.Breit);
            labelMobiliarFlächen.Text = sc.Flaechen.ToString();
            if (comboBoxMieter.SelectedIndex != -1)
            {
                Mieter m = (Mieter)comboBoxMieter.SelectedItem;
                sc.Mitkennzeichen = m.Kennzeichen;
            }
            else { sc.Mitkennzeichen = 0; }

            distinctMobiliar();
            allSchrank.Add(sc);
#endregion
        }

        public void getallMobiliar()
        {
            #region bekommen allMobiliarList
            allMobiliar.Clear();

            for (int i = 0; i < allStuhl.Count; i++)
            {
                allMobiliar.Add(allStuhl[i]);
            }
            for (int i = 0; i < allTisch.Count; i++)
            {
                allMobiliar.Add(allTisch[i]);
            }
            for (int i = 0; i < allSchrank.Count; i++)
            {
                allMobiliar.Add(allSchrank[i]);
            }         
#endregion
        }

        public void addMobiliar()
        {
            #region listBoxMobiliar füllen
            string a = comboBoxMobiliar.SelectedItem.ToString();
            switch (a)
            {
                case "Stuhl":
                    getallStuhl();
                    foreach (Stuhl st in allStuhl)
                    {
                        listBoxMobiliar.Items.Add(st);
                    }
                    break;

                case "Tisch":
                    getallTisch();
                    foreach (Tisch ti in allTisch)
                    {
                        listBoxMobiliar.Items.Add(ti);
                    }
                    break;

                case "Schrank":
                    getallSchrank();
                    foreach (Schrank sc in allSchrank)
                    {
                        listBoxMobiliar.Items.Add(sc);
                    }
                    break;
            }
#endregion
        }

        public void removeMobiliar()
        {
            #region listBoxMobiliar löschen
            string a = comboBoxMobiliar.SelectedItem.ToString();

            switch (a)
            {
                case "Stuhl":
                    {
                        for (int i = 0; i < allStuhl.Count; i++)
                        {
                            if (stuhl.Equals(allStuhl[i]))
                            {
                                allStuhl.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;

                case "Tisch":
                    {
                        for (int i = 0; i < allTisch.Count; i++)
                        {
                            if (tisch.Equals(allTisch[i]))
                            {
                                allTisch.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;

                case "Schrank":
                    {
                        for (int i = 0; i < allSchrank.Count; i++)
                        {
                            if (schrank.Equals(allSchrank[i]))
                            {
                                allSchrank.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;
            }
#endregion
        }

        public void auslesenMobiliar()
        {
            #region listBoxMobiliar auslesen
            clearMobiliartext();

            string a = comboBoxMobiliar.SelectedItem.ToString();

            //Daten ablesen von listBoxMobiliar
            switch (a)
            {
                case "Stuhl":
                    {
                        Stuhl st = (Stuhl)listBoxMobiliar.SelectedItem;
                        stuhl = st;
                        textBoxMobiliarKennzeichen.Text = st.Kennzeichen.ToString();
                        switch (st.Zustand)
                        {
                            case "defekt":
                                {
                                    comboBoxMobiliarZustand.SelectedIndex = 0;
                                }
                                break;

                            case "beschädigt":
                                {
                                    comboBoxMobiliarZustand.SelectedIndex = 1;
                                }
                                break;

                            case "intakt":
                                {
                                    comboBoxMobiliarZustand.SelectedIndex = 2;
                                }
                                break;
                        }
                        textBoxMobiliarMaterial.Text = st.Material;
                        textBoxMobiliarWert.Text = st.Wert.ToString();
                        textBoxMobiliarLength.Text = st.Length.ToString();
                        textBoxMobiliarBreite.Text = st.Breit.ToString();
                        textBoxMobiliarHöhe.Text = st.Hoehe.ToString();
                        labelMobiliarFlächen.Text = st.Flaechen.ToString();

                        foreach(Raum ra in allRaum)
                        {
                            if(ra.getName() == st.Raumkennzeichen)
                            {
                                int idx = allRaum.IndexOf(ra);
                                comboBoxMobiliarRaum.SelectedIndex = idx;
                                break;
                            }
                        }
 
                        foreach (Mieter mi in allMieters)
                        {
                            if (st.Mitkennzeichen == mi.Kennzeichen)
                            {
                                int idx = allMieters.IndexOf(mi);
                                comboBoxMieter.SelectedIndex = idx;
                                break;
                            }
                        }
                    }
                    break;

                case "Tisch":
                    {
                        Tisch ti = (Tisch)listBoxMobiliar.SelectedItem;
                        tisch = ti;
                        textBoxMobiliarKennzeichen.Text = ti.Kennzeichen.ToString();
                        switch (ti.Zustand)
                        {
                            case "defekt":
                                {
                                    comboBoxMobiliarZustand.SelectedIndex = 0;
                                }
                                break;

                            case "beschädigt":
                                {
                                    comboBoxMobiliarZustand.SelectedIndex = 1;
                                }
                                break;

                            case "intakt":
                                {
                                    comboBoxMobiliarZustand.SelectedIndex = 2;
                                }
                                break;
                        }
                        textBoxMobiliarMaterial.Text = ti.Material;
                        textBoxMobiliarWert.Text = ti.Wert.ToString();
                        textBoxMobiliarLength.Text = ti.Length.ToString();
                        textBoxMobiliarBreite.Text = ti.Breit.ToString();
                        textBoxMobiliarHöhe.Text = ti.Hoehe.ToString();
                        labelMobiliarFlächen.Text = ti.Flaechen.ToString();

                        foreach (Raum ra in allRaum)
                        {
                            if (ra.getName() == ti.Raumkennzeichen)
                            {
                                int idx = allRaum.IndexOf(ra);
                                comboBoxMobiliarRaum.SelectedIndex = idx;
                                break;
                            }
                        }

                        foreach (Mieter mi in allMieters)
                        {
                            if (ti.Mitkennzeichen == mi.Kennzeichen)
                            {
                                int idx = allMieters.IndexOf(mi);
                                comboBoxMieter.SelectedIndex = idx;
                                break;
                            }
                        }
                    }
                    break;

                case "Schrank":
                    {
                        Schrank sc = (Schrank)listBoxMobiliar.SelectedItem;
                        schrank = sc;
                        textBoxMobiliarKennzeichen.Text = sc.Kennzeichen.ToString();
                        switch (sc.Zustand)
                        {
                            case "defekt":
                                {
                                    comboBoxMobiliarZustand.SelectedIndex = 0;
                                }
                                break;

                            case "beschädigt":
                                {
                                    comboBoxMobiliarZustand.SelectedIndex = 1;
                                }
                                break;

                            case "intakt":
                                {
                                    comboBoxMobiliarZustand.SelectedIndex = 2;
                                }
                                break;
                        }
                        textBoxMobiliarMaterial.Text = sc.Material;
                        textBoxMobiliarWert.Text = sc.Wert.ToString();
                        textBoxMobiliarLength.Text = sc.Length.ToString();
                        textBoxMobiliarBreite.Text = sc.Breit.ToString();
                        textBoxMobiliarHöhe.Text = sc.Hoehe.ToString();
                        labelMobiliarFlächen.Text = sc.Flaechen.ToString();

                        foreach (Raum ra in allRaum)
                        {
                            if (ra.getName() == sc.Raumkennzeichen)
                            {
                                int idx = allRaum.IndexOf(ra);
                                comboBoxMobiliarRaum.SelectedIndex = idx;
                                break;
                            }
                        }

                        foreach (Mieter mi in allMieters)
                        {
                            if (sc.Mitkennzeichen == mi.Kennzeichen)
                            {
                                int idx = allMieters.IndexOf(mi);
                                comboBoxMieter.SelectedIndex = idx;
                                break;
                            }
                        }
                    }
                    break;
            }
#endregion
        }

        public void refreshMobiliar()
        {
            #region listBoxRaum aktualisieren
            string a = comboBoxMobiliar.SelectedItem.ToString();

            switch (a)
            {
                case "Stuhl":
                    foreach (Stuhl st in allStuhl)
                    {
                        listBoxMobiliar.Items.Add(st);
                    }
                    break;

                case "Tisch":
                    foreach (Tisch ti in allTisch)
                    {
                        listBoxMobiliar.Items.Add(ti);
                    }
                    break;

                case "Schrank":
                    foreach (Schrank sc in allSchrank)
                    {
                        listBoxMobiliar.Items.Add(sc);
                    }
                    break;
            }
#endregion
        }

        public void clearMobiliartext()
        {
            #region Clear textBox für Mobiliar
            textBoxMobiliarKennzeichen.Clear();
            textBoxMobiliarLength.Clear();
            textBoxMobiliarBreite.Clear();
            textBoxMobiliarHöhe.Clear();
            textBoxMobiliarMaterial.Clear();
            textBoxMobiliarWert.Clear();
            comboBoxMieter.SelectedItem = null;
            comboBoxMobiliarZustand.SelectedItem = null;
            labelMobiliarFlächen.Text = null;
            comboBoxMobiliarRaum.SelectedItem = null;
#endregion
        }

        public List<string> getMobiliarWert()
        {
            #region get Mobiliar Wert
            List<string> hs = new List<string>();
            string A = comboBoxMieter.SelectedItem.ToString();
            string[] B = A.Split('.');
            int C = int.Parse(B[0]);
            foreach (Mobiliar mob in allMobiliar)
            {
                if (C == mob.Mitkennzeichen)
                {
                    string a = mob.getName();
                    hs.Add(a + ":    " + mob.Wert.ToString() + " Euro");                    
                }
            }
            return hs;
#endregion
        }

        public void MobiliarSerialisierung()
        {
            if (comboBoxMobiliar.SelectedItem == null)
            {
                MessageBox.Show("Typ des Mobiliars wählen Zuerst!");
            }
            else
            {
                string a = comboBoxMobiliar.SelectedItem.ToString();

                switch (a)
                {
                    case "Stuhl":
                        {
                            getallStuhl();
                            if (allStuhl.Count == 0)
                            {
                                MessageBox.Show("Speichern Zuerst!");
                            }
                            else
                            {
                                SaveFileDialog sfd = new SaveFileDialog();

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Stuhl st in allStuhl)
                                    {
                                        st.speichern(sfd.FileName, allStuhl);
                                    }
                                }
                            }
                        }
                        break;

                    case "Tisch":
                        {
                            getallTisch();
                            if (allTisch.Count == 0)
                            {
                                MessageBox.Show("Speichern Zuerst!");
                            }
                            else
                            {
                                SaveFileDialog sfd = new SaveFileDialog();

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Tisch ti in allTisch)
                                    {
                                        ti.speichern(sfd.FileName, allTisch);
                                    }
                                }
                            }
                        }
                        break;

                    case "Schrank":
                        {
                            getallSchrank();
                            if (allSchrank.Count == 0)
                            {
                                MessageBox.Show("Speichern Zuerst!");
                            }
                            else
                            {
                                SaveFileDialog sfd = new SaveFileDialog();

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Schrank sc in allSchrank)
                                    {
                                        sc.speichern(sfd.FileName, allSchrank);
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }

        public void MobiliarDeserialisierung()
        {
            if (comboBoxMobiliar.SelectedItem == null)
            {
                MessageBox.Show("Type des Möbels wählen Zuerst!");
            }
            else
            {
                string a = comboBoxMobiliar.SelectedItem.ToString();

                switch (a)
                {
                    case "Stuhl":
                        {
                            listBoxMobiliar.Items.Clear();
                            OpenFileDialog ofds = new OpenFileDialog();
                            if (ofds.ShowDialog() == DialogResult.OK)
                            {
                                List<Stuhl> st = new List<Stuhl>();
                                st = Stuhl.laden(ofds.FileName);
                                for (int i = 0; i < st.Count; i++)
                                {
                                    listBoxMobiliar.Items.Add(st[i]);
                                }
                            }
                        }
                        break;

                    case "Tisch":
                        {
                            listBoxMobiliar.Items.Clear();
                            OpenFileDialog ofdt = new OpenFileDialog();
                            if (ofdt.ShowDialog() == DialogResult.OK)
                            {
                                List<Tisch> ti = new List<Tisch>();
                                ti = Tisch.laden(ofdt.FileName);
                                for (int i = 0; i < ti.Count; i++)
                                {
                                    listBoxMobiliar.Items.Add(ti[i]);
                                }
                            }
                        }
                        break;

                    case "Schrank":
                        {
                            listBoxMobiliar.Items.Clear();
                            OpenFileDialog ofdc = new OpenFileDialog();
                            if (ofdc.ShowDialog() == DialogResult.OK)
                            {
                                List<Schrank> sc = new List<Schrank>();
                                sc = Schrank.laden(ofdc.FileName);
                                for (int i = 0; i < sc.Count; i++)
                                {
                                    listBoxMobiliar.Items.Add(sc[i]);
                                }
                            }
                        }
                        break;
                }
            }
        }

#endregion

        #region Methode für Besitzer und Mieter
        public void distinctBeMi()
        {
            #region löschen die gleiche Item in Besitzer
            int m = int.Parse(textBoxBeMiKennzeichen.Text);
            string a = comboBoxBeMi.SelectedItem.ToString();
            try
            {
                //füllen listBoxRaum
                switch (a)
                {
                    case "Besitzer":
                        {
                            foreach (Besitzer x in allBesitzers)
                            {
                                if (x.Kennzeichen == m)
                                {
                                    allBesitzers.Remove(x);
                                }
                            }
                        }
                        break;
                    case "Mieter":
                        {
                            foreach (Mieter x in allMieters)
                            {
                                if (x.Kennzeichen == m)
                                {
                                    allMieters.Remove(x);
                                }
                            }
                        }
                        break;
                }
            }
            catch { };
#endregion
        }

        public void getallBesitzer()
        {
            #region geben die Daten für Besitzer
            Besitzer b = new Besitzer();

            b.Kennzeichen = int.Parse(textBoxBeMiKennzeichen.Text);
            b.Vorname = textBoxBeMiVorname.Text;
            b.Nachname = textBoxBeMiNachname.Text;
            b.Email = textBoxBeMiEmail.Text;
            b.Mobilphone = textBoxBeMiMobilphone.Text;
            b.Addresse = textBoxBeMiAddresse.Text;

            distinctBeMi();
            allBesitzers.Add(b);
#endregion
        }

        public void getallMieter()
        {
            #region geben die Datenfür Mieter
            Mieter m = new Mieter();

            m.Kennzeichen = int.Parse(textBoxBeMiKennzeichen.Text);
            m.Vorname = textBoxBeMiVorname.Text;
            m.Nachname = textBoxBeMiNachname.Text;
            m.Email = textBoxBeMiEmail.Text;
            m.Mobilphone = textBoxBeMiMobilphone.Text;
            m.Addresse = textBoxBeMiAddresse.Text;

            distinctBeMi();
            allMieters.Add(m);
#endregion
        }

        public void addBeMi()
        {
            #region listBoxBeMi füllen
            string m = comboBoxBeMi.SelectedItem.ToString();
            switch (m)
            {
                case "Besitzer":
                    {
                        getallBesitzer();                      
                        foreach (Besitzer b in allBesitzers)
                        {
                            listBoxBeMi.Items.Add(b);
                        }
                    }
                    break;

                case "Mieter":
                    {
                        getallMieter();
                        foreach (Mieter mi in allMieters)
                        {
                            listBoxBeMi.Items.Add(mi);
                        }
                    }
                    break;
            }
#endregion
        }
       
        public void removeBeMi()
        {
            #region listBoxBeMi löschen
            string m = comboBoxBeMi.SelectedItem.ToString();

            switch (m)
            {
                case "Besitzer":
                    {
                        for (int i = 0; i < allBesitzers.Count; i++)
                        {
                            if (besitzer.Equals(allBesitzers[i]))
                            {
                                allBesitzers.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;

                case "Mieter":
                    {
                        for (int i = 0; i < allMieters.Count; i++)
                        {
                            if (mieter.Equals(allMieters[i]))
                            {
                                allMieters.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    break;
            }
#endregion
        }

        public void auslesenBeMi()
        {
            #region listBoxBeMi auslesen
            clearBeMitext();
            string a = comboBoxBeMi.SelectedItem.ToString();

            //Daten ablesen von listBoxMobiliar
            switch (a)
            {
                case "Besitzer":
                    {
                        Besitzer b = (Besitzer)listBoxBeMi.SelectedItem;
                        besitzer = b;
                        textBoxBeMiVorname.Text = b.Vorname;
                        textBoxBeMiNachname.Text = b.Nachname;
                        textBoxBeMiKennzeichen.Text = b.Kennzeichen.ToString();
                        textBoxBeMiEmail.Text = b.Email;
                        textBoxBeMiMobilphone.Text = b.Mobilphone;
                        textBoxBeMiAddresse.Text = b.Addresse;
                    }
                    break;

                case "Mieter":
                    {
                        Mieter m = (Mieter)listBoxBeMi.SelectedItem;
                        mieter = m;
                        textBoxBeMiVorname.Text = m.Vorname;
                        textBoxBeMiNachname.Text = m.Nachname;
                        textBoxBeMiKennzeichen.Text = m.Kennzeichen.ToString();
                        textBoxBeMiEmail.Text = m.Email;
                        textBoxBeMiMobilphone.Text = m.Mobilphone;
                        textBoxBeMiAddresse.Text = m.Addresse;
                    }
                    break;
            }
#endregion
        }

        public void refreshBeMi()
        {
            #region listBoxBeMi aktualisieren
            string m = comboBoxBeMi.SelectedItem.ToString();
            switch (m)
            {
                case "Besitzer":
                    {
                        foreach (Besitzer be in allBesitzers)
                        {
                            listBoxBeMi.Items.Add(be);
                        }
                    }
                    break;

                case "Mieter":
                    {
                        foreach (Mieter mi in allMieters)
                        {
                            listBoxBeMi.Items.Add(mi);
                        }
                    }
                    break;
            }
#endregion
        }

        public void clearBeMitext()
        {
            #region Clear textBox für Besitzer und Mieter
            textBoxBeMiVorname.Clear();
            textBoxBeMiKennzeichen.Clear();
            textBoxBeMiNachname.Clear();
            textBoxBeMiEmail.Clear();
            textBoxBeMiMobilphone.Clear();
            textBoxBeMiAddresse.Clear();
#endregion
        }

        public void BeMiSerialisierung()
        {
            if (comboBoxBeMi.SelectedItem == null)
            {
                MessageBox.Show("Besitzer oder Mieter wählen Zuerst!");
            }
            else
            {
                string a = comboBoxBeMi.SelectedItem.ToString();

                switch (a)
                {
                    case "Besitzer":
                        {
                            getallBesitzer();
                            if (allBesitzers.Count == 0)
                            {
                                MessageBox.Show("Speichern Zuerst!");
                            }
                            else
                            {
                                SaveFileDialog sfd = new SaveFileDialog();

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Besitzer be in allBesitzers)
                                    {
                                        be.speichern(sfd.FileName, allBesitzers);
                                    }
                                }
                            }
                        }
                        break;

                    case "Mieter":
                        {
                            getallMieter();
                            if (allMieters.Count == 0)
                            {
                                MessageBox.Show("Speichern Zuerst!");
                            }
                            else
                            {
                                SaveFileDialog sfd = new SaveFileDialog();

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    foreach (Mieter mi in allMieters)
                                    {
                                        mi.speichern(sfd.FileName, allMieters);
                                    }
                                }
                            }
                        }
                        break;
                }
            }
        }

        public void BeMiDeserialisierung()
        {
            if (comboBoxBeMi.SelectedItem == null)
            {
                MessageBox.Show("Besitzer oder Mieter wählen Zuerst!");
            }
            else
            {
                string a = comboBoxBeMi.SelectedItem.ToString();

                switch (a)
                {
                    case "Besitzer":
                        {
                            listBoxBeMi.Items.Clear();
                            OpenFileDialog ofds = new OpenFileDialog();
                            if (ofds.ShowDialog() == DialogResult.OK)
                            {
                                List<Besitzer> be = new List<Besitzer>();
                                be = Besitzer.laden(ofds.FileName);
                                for (int i = 0; i < be.Count; i++)
                                {
                                    listBoxBeMi.Items.Add(be[i]);
                                }
                            }
                        }
                        break;

                    case "Mieter":
                        {
                            listBoxBeMi.Items.Clear();
                            OpenFileDialog ofdt = new OpenFileDialog();
                            if (ofdt.ShowDialog() == DialogResult.OK)
                            {
                                List<Mieter> mi = new List<Mieter>();
                                mi = Mieter.laden(ofdt.FileName);
                                for (int i = 0; i < mi.Count; i++)
                                {
                                    listBoxBeMi.Items.Add(mi[i]);
                                }
                            }
                        }
                        break;
                }
            }
        }
        #endregion

        private void comboBoxBereich_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Nutzungsart in comboBoxNutzung hinzufügen
            object it = comboBoxBereich.SelectedItem;
            string ite = it.ToString();
            
            switch (ite)
            {
                case "Bürobereich":
                    {
                        comboBoxNutzung.Items.Clear();
                        comboBoxNutzung.Items.Add(nut[0]);
                    }
                    break;
                case "Lagernbereich":
                    {
                        comboBoxNutzung.Items.Clear();
                        comboBoxNutzung.Items.Add(nut[1]);
                    }
                    break;
                case "Gemeinschaftsbereich":
                    {
                        comboBoxNutzung.Items.Clear();
                        comboBoxNutzung.Items.Add(nut[2]);
                        comboBoxNutzung.Items.Add(nut[3]);
                        comboBoxNutzung.Items.Add(nut[4]);
                    }
                    break;
                case "Ruhezone":
                    {
                        comboBoxNutzung.Items.Clear();
                        comboBoxNutzung.Items.Add(nut[5]);
                    }
                    break;
            }
        }

        private void comboBoxNutzung_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///clearRaumtext();
            listBoxRaum.Items.Clear();
            try
            { 
                refreshRaum();
                getBereichGeroesse();
            }
            catch { };
            
        }

        private void comboBoxMobiliar_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///clearMobiliartext();
            listBoxMobiliar.Items.Clear();
            try
            {
                refreshMobiliar();
            }
            catch { }
        }

        private void comboBoxBeMi_SelectedIndexChanged(object sender, EventArgs e)
        {
           /// clearBeMitext();           
            listBoxBeMi.Items.Clear();
            try
            {
                refreshBeMi();
            }
            catch { }
        }


        //Raum
        private void buttonRaumspeichern_Click(object sender, EventArgs e)
        {
            listBoxRaum.Items.Clear();
            try
            {
                addRaum();
                getBereichGeroesse();
                //getBesitzer();
                //getMieter();
            }
            catch
            {
                MessageBox.Show("Bitte eingeben die Parameter!");
            }
            clearRaumtext();
            getallRaum();
            foreach(Raum ra in allRaum)
            {
                comboBoxMobiliarRaum.Items.Add(ra);
            }
        }

        private void buttonRaumentfernen_Click(object sender, EventArgs e)
        {
            listBoxRaum.Items.Clear();
            clearRaumtext();
            try
            {
                removeRaum();
                refreshRaum();
                getBereichGeroesse();
            }
            catch
            {
                MessageBox.Show("Bitte wählen Sie ein Raum aus!");
            }
        }

        private void buttonRaumDetails_Click(object sender, EventArgs e)
        {
            string a = listBoxRaum.SelectedItem.GetType().Name;
            string[] m = a.Split(' ');
            try
            {
                if (m[0] == "Buero")
                {
                    List<string> lis = getRaumMob(buero);

                    Form2 f2 = new Form2(buero, lis);
                    f2.Show();
                    lis.Clear();
                }
                if (m[0] == "Lagern")
                {
                    List<string> lis = getRaumMob(lagern);

                    Form2 f2 = new Form2(lagern, lis);
                    f2.Show();
                    lis.Clear();
                }
                if (m[0] == "Flur")
                {
                    List<string> lis = getRaumMob(flur);

                    Form2 f2 = new Form2(flur, lis);
                    f2.Show();
                    lis.Clear();
                }
                if (m[0] == "Seminarraum")
                {
                    List<string> lis = getRaumMob(seminarraum);

                    Form2 f2 = new Form2(seminarraum, lis);
                    f2.Show();
                    lis.Clear();
                }
                if (m[0] == "Sanitaerraum")
                {
                    List<string> lis = getRaumMob(sanitaerraum);

                    Form2 f2 = new Form2(sanitaerraum, lis);
                    f2.Show();
                    lis.Clear();
                }
                if (m[0] == "Ruheraum")
                {
                    List<string> lis = getRaumMob(ruheraum);

                    Form2 f2 = new Form2(ruheraum, lis);
                    f2.Show();
                    lis.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Bitte wählen Sie ein Raum aus!");
            }

           
        }

        private void listBoxRaum_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                auslesenRaum();
            }
            catch { }
        }

        private void buttonRaumSerialisierung_Click(object sender, EventArgs e)
        {
            Raumserialisierung();
        }

        private void buttonRaumDeserialisierung_Click(object sender, EventArgs e)
        {
            Raumdeserialisierung();
        }


        //Mobiliar
        private void buttonMobiliarspeichern_Click(object sender, EventArgs e)
        {
            listBoxMobiliar.Items.Clear();
            try
            {
                addMobiliar();
                getallMobiliar();
            }
            catch { MessageBox.Show("Bitte eingeben die Parameter!"); }
            clearMobiliartext();
        }

        private void buttonMobiliarentfernen_Click(object sender, EventArgs e)
        {
            listBoxMobiliar.Items.Clear();
            clearMobiliartext();
            try
            {
                removeMobiliar();
                refreshMobiliar();
            }
            catch { MessageBox.Show("Bitte wählen Sie ein Möbel aus!"); }
        }

        private void buttonMobiliarDetails_Click(object sender, EventArgs e)
        {
            double m = 0;
            List<string> h = new List<string>();

            getallMobiliar();
            try
            {
                h = getMobiliarWert();
            }
            catch { }
            foreach (string de in h)
            {
                string[] st = de.Split(':',' ');
                double n = Convert.ToDouble(st[5]);
                m += n;
            }
            try
            {
                Form3 f3 = new Form3(((Mobiliar)listBoxMobiliar.SelectedItem), (Mieter)comboBoxMieter.SelectedItem, (double)m, (List<string>)h);
                f3.Show();
            }
            catch
            {
                MessageBox.Show("Bitte wählen Sie ein Möbel aus");
            }

            h.Clear();
        }

        private void listBoxMobiliar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                auslesenMobiliar();
            }
            catch { }
        }

        private void buttonMobiliarSerialisierung_Click(object sender, EventArgs e)
        {
            MobiliarSerialisierung();
        }

        private void buttonMobiliarDeserialisierung_Click(object sender, EventArgs e)
        {
            MobiliarDeserialisierung();
        }


        //Besitzer und Mieter
        private void buttonBeMiSpeichern_Click(object sender, EventArgs e)
        {
            listBoxBeMi.Items.Clear();
            try
            {
                addBeMi();
            }
            catch { MessageBox.Show("Bitte eingeben die Parameter!"); }
            clearBeMitext();

            //Mieter in comboBoxMieter hinzufügen
            comboBoxMieter.Items.Clear();
            for (int i = 0; i < allMieters.Count; i++)
            {
                comboBoxMieter.Items.Add(allMieters[i]);
            }

            comboBoxRaumMieter.Items.Clear();
            for (int i = 0; i < allMieters.Count; i++)
            {
                comboBoxRaumMieter.Items.Add(allMieters[i]);
            }

            comboBoxRaumBesitzer.Items.Clear();
            for (int i = 0; i < allBesitzers.Count; i++)
            {
                comboBoxRaumBesitzer.Items.Add(allBesitzers[i]);
            }
        }

        private void buttonBeMientfernen_Click(object sender, EventArgs e)
        {
            listBoxBeMi.Items.Clear();
            clearBeMitext();
            try
            {
                removeBeMi();
                refreshBeMi();
            }
            catch { MessageBox.Show("Bitte wählen Sie ein Besitzer oder ein Mieter aus"); }
        }

        private void listBoxBeMi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                auslesenBeMi();
            }
            catch { }
        }

        private void buttonBeMiSerialisierung_Click(object sender, EventArgs e)
        {
            BeMiSerialisierung();
        }

        private void buttonBeMiDeserialisierung_Click(object sender, EventArgs e)
        {
            BeMiDeserialisierung();
        }

        private void buttonRaumzeigen_Click(object sender, EventArgs e)
        {
            string a = comboBoxBeMi.SelectedItem.ToString();
            switch(a)
            {
                case "Besitzer":
                    {
                        Besitzer be = (Besitzer)listBoxBeMi.SelectedItem;
                        foreach (Raum ra in allRaum)
                        {
                            if (ra.Besitzer == be.getName())
                            {
                                be.BesitzerRaum.Add(ra);
                            }
                        }
                        Form4 f4 = new Form4(be);
                        f4.Show();
                    }
                    break;
                case "Mieter":
                    {
                        Mieter mi = (Mieter)listBoxBeMi.SelectedItem;
                        foreach (Raum ra in allRaum)
                        {
                            if (ra.Mieter == mi.getName())
                            {
                                mi.MieterRaum.Add(ra);
                            }
                        }
                        Form5 f5 = new Form5(mi);
                        f5.Show();
                    }
                    break;
            }

        }
    }
}
    

