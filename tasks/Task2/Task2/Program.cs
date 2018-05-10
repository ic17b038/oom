using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Mitarbeiter
    {
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
