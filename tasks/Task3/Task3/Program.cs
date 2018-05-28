using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task3
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
        private string name;
        private decimal gehalt;

        //Konstruktor
        public Mitarbeiter(decimal newgehalt, string dername)
        {
            if (newgehalt <= 0)
                throw new Exception("Gehalt darf nicht 0 oder drunter sein");
            name = dername;
            gehalt = newgehalt;
        }

        //public methods
        public string GetName()
        { return name; }

        public decimal GetGehalt()
        { return gehalt; }

        public void ShowGehalt(decimal ggehalt)
        {
            if (gehalt > 1000)
                Console.WriteLine("ok cool");

            ggehalt = 1200;
            gehalt = ggehalt;
        }

    }


    //zweite Klasse welches ebenfalls Interface implementiert
    class Kunden: Abteilung
    {
        //Interface Implementierung
        public string getAbteilung()
        {
            string abteilung;
            abteilung = "Development";
            return abteilung;
        }

        //private fields
        

        public Kunden(string dername, double dasalter)
        {
            if(dername!="Martha")
                throw new Exception("Du bist nicht Batmans Mutter");
            Name = dername;
            Alter = dasalter;
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
                Console.WriteLine(a.GetName());
                Console.WriteLine(a.GetGehalt());
                //calling method and printing effects
                a.ShowGehalt(a.GetGehalt());
                Console.WriteLine(a.GetGehalt());
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
            Console.WriteLine(x.GetGehalt());

            
            Kunden y = (Kunden)test[1];
            Console.WriteLine(y.Name);


            Console.WriteLine("-----Loop Ergaenzung----");
            //Loop over array of objects
            foreach (var element in test)
            {
                Console.WriteLine(x.GetGehalt());
                Console.WriteLine(y.Name);
            }

        }
    }
}
