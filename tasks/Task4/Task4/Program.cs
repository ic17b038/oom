﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace Task4
{
    //Interface
    interface Abteilung
    {
        string getAbteilung();
    }

    //Interface Zuweisung
    class Mitarbeiter : Abteilung
    {
        //Interface Implementierung
        public string getAbteilung()
        {
            string abteilung;
            abteilung = "Development";
            return abteilung;
        }

        //private fields
        //private string name;
        //private decimal gehalt;

        //Konstruktor
        public Mitarbeiter(decimal Gehaltt, string Namee)
        {
            if (Gehaltt <= 0)
                throw new Exception("Gehalt darf nicht 0 oder drunter sein");
            if(Namee=="")
                throw new Exception("Name ist leer");
            this.Namee = Namee;
            this.Gehaltt = Gehaltt;
        }

        
        public string Namee
        { get; }

        public decimal Gehaltt
        { get; }

        public void ShowGehalt(decimal ggehalt)
        {
            if (Gehaltt > 1000)
                Console.WriteLine("ok cool");

            ggehalt = 1200;
            
        }

    }


    //zweite Klasse welches ebenfalls Interface implementiert
    class Kunden : Abteilung
    {
        //Interface Implementierung
        public string getAbteilung()
        {
            string abteilung;
            abteilung = "Development";
            return abteilung;
        }

        //private fields


        public Kunden(string Name, double Alter)
        {
            if (Name != "Martha")
                throw new Exception("Du bist nicht Batmans Mutter");
            if(Alter ==0 || Name==null)
                throw new Exception("Einer der beiden Werte ist nicht ausgefüllt");
            this.Name = Name;
            this.Alter = Alter;
        }

        public string Name { get; }

        public double Alter { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //new object of class
            Mitarbeiter a = new Mitarbeiter(1800, "Hans");
            try
            {
                //printing properties of objects
                Console.WriteLine(a.Namee);
                Console.WriteLine(a.Gehaltt);
                //calling method and printing effects
                a.ShowGehalt(a.Gehaltt);
                Console.WriteLine(a.Gehaltt);
            }



            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("----Task3 ab hier-----");

            //Array vom Interface type welches ein Mix aus Instanzen der Klassen enthaelt
            var test = new Abteilung[]
                {
                    new Mitarbeiter(1400,"Peter"),
                     new Kunden("Martha", 55),
                };

            Mitarbeiter x = (Mitarbeiter)test[0];
            Console.WriteLine(x.Gehaltt);

            Kunden y = (Kunden)test[1];
            Console.WriteLine(y.Name);


            Console.WriteLine("----Task4 ab hier-----");
            var testx = new Abteilung[]
               {
                    new Mitarbeiter(1400,"Peter"),
                     new Kunden("Martha", 55),
               };

            Console.WriteLine("----------Serialization----------");
            var settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto, Formatting = Formatting.Indented };

            File.WriteAllText(@"C:\Users\Baris\oom\tasks\test.json", JsonConvert.SerializeObject(testx, settings));

            Console.WriteLine(System.IO.File.ReadAllText(@"C:\Users\Baris\oom\tasks\test.json"));


            Console.WriteLine("----------Deserialitaion----------");

            //Methode 1: Gibt mir einen "Could not create instance of type Array" error

            string blabla=File.ReadAllText(@"C:\Users\Baris\oom\tasks\test.json");

            var uff = JsonConvert.DeserializeObject<Abteilung[]>(blabla, settings);

            Console.WriteLine(blabla);

            //Methode 2=> gibt mir einen "unexpected character" error

            //List<string> jaja = JsonConvert.DeserializeObject<List<string>>(blabla);

            //Console.WriteLine(string.Join(", ", jaja.ToArray()));

        }
    }
}
