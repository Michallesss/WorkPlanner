using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner
{
    public class Task
    {
        public string name;
        string description;
        double price;
        DateTime startDate;
        DateTime endDate;

        public Task()
        {
            Console.Write("Podaj nazwe zadania: ");
            this.name = Console.ReadLine();

            Console.Write("Podaj opis zadania: ");
            this.description = Console.ReadLine();

            Console.Write("Podaj cene zadania: ");
            this.price = Convert.ToDouble(Console.ReadLine());
        }

        public void GenerateMenu()
        {
            Console.WriteLine("Menu Zadania:");
            if (this.startDate == null)
                Console.WriteLine("1.Rozpocznij");
            else
                Console.WriteLine("1.Zakończ");
            Console.WriteLine("2.Raport");
            Console.WriteLine("3.Informacje");
            Console.Write("Twój wybór: ");
            switch (Console.ReadLine())
            {
                case "1":
                    if (this.startDate == null)
                        this.EndTask();
                    else
                        this.StartTask();
                    break;
                case "2":
                    this.RaportTask();
                    break;
                case "3":
                    this.DisplayTask();
                    break;
            }
        }

        void StartTask()
        {
            this.startDate = DateTime.Now;
            Console.WriteLine("Zadanie zaczęte");
        }

        void EndTask()
        {
            this.endDate = DateTime.Now;
            Console.WriteLine("Zadanie zakończone");
        }

        void DisplayTask()
        {
            Console.WriteLine("Informacje");
            Console.WriteLine("Nazwa: " + this.name);
            Console.WriteLine("Opis: " + this.description);
            Console.WriteLine("Data zaczęcia: " + this.startDate);
            Console.WriteLine("Data zakończenia: " + this.endDate);
            Console.Write("Kliknij aby kontynuować..");
            Console.ReadLine();
        }

        void RaportTask()
        {
            if (this.endDate != null)
            {
                Console.WriteLine("Godziny spędzone: ");
                Console.WriteLine("Płaca: " + this.price);
                Console.WriteLine("Płaca/Godzine: ");
            }
            else
            {
                Console.WriteLine("Zadanie jeszcze nie zostało zakończone..");
                Console.ReadLine();
            }
        }
    }
}
