using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;



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
        public static Task<bool> task7func(int k, int j)
        {
            return Task.Run(() =>
            {
                if(k+j==10)
                {
                    return false;
                }
                return true;
            });
        }

        public static async Task blubla(int j)
        {
                int k = 10;
                if (await task7func(k,j)) WriteLine($"[P] prime number:{k}");
            
        }

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


            Console.WriteLine("-----------Task6-Subject---------");

            var sub = new Subject<Mitarbeiter>(); //Producer vom stream

            sub.Subscribe(l => Console.WriteLine($"received value: {l.Namee}")); //Empfanger vom Stream
            
            for(var i=0;i<5;i++)
            {
                Thread.Sleep(250);
                
                sub.OnNext(new Mitarbeiter(1000,"pete")); //Stream Fueterung
            }

            var p = new Thread(() =>
            {
                int o = 4;
                while (o != 0)
                {
                    Thread.Sleep(250);
                    sub.OnNext(new Mitarbeiter(800, "Hans"));
                    o--;
                }
            });
            p.Start();


            Console.WriteLine("-----------Task7 ab hier---------");

            //starting tasks using Task.Run

            var tasks = new List<Task<int>>();

           
                var task = Task.Run(() =>
                  {
                      //Task.Delay(800);
                      Console.WriteLine($"[T] Test");
                      return 5;
                  });
                
                tasks.Add(task);


            //continuewith
            var tasks2 = new List<Task<int>>();
            foreach (var taskx in tasks)
            {
                tasks2.Add(
                    taskx.ContinueWith(r => { WriteLine($"[C] ergebni {r.Result}");return r.Result; })
                    );
            }

            //await
            var primetask = blubla(5);

            
           
        }
    }
}
