using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlanner
{
    public class User
    {
        string name;
        List<WorkDay> workDays = new List<WorkDay>() { };
        List<Task> tasks = new List<Task>() { };

        public User()
        {
            Console.Write("Podaj nazwe: ");
            this.name = Console.ReadLine();

            Console.Write("Ile dni w tygodniu pracujesz: ");
            int days = Convert.ToInt32(Console.ReadLine());
            for (int day = 1; day <= days; day++)
                workDays.Add(new WorkDay(day));

            Console.WriteLine("Uzytkownik dodany..");
            Console.ReadLine();
        }

        public void GenerateMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1.DODAJ zadanie");
            Console.WriteLine("2.WYŚWIETL zadania");
            Console.WriteLine("3.WYŚWIETL dni pracy");
            Console.WriteLine("4.WYŚWIETL plan pracy");
            Console.Write("Twój wybór: ");
            switch (Console.ReadLine())
            {
                case "1":
                    tasks.Add(new Task());
                    tasks.Last().GenerateMenu();
                    break;
                case "2":
                    TasksList();
                    break;
                case "3":
                    WorkDaysList();
                    break;
                case "4":
                    WorkPlan();
                    break;
            }
        }

        void TasksList()
        {
            Console.WriteLine("Lista Zadan: ");
            for (int i = 0; i < tasks.Count; i++)
                Console.WriteLine(i + " " + tasks[i].name);

            if (tasks.Count<1)
            {
                Console.WriteLine("[brak zadań]");
                Console.WriteLine("Brak możliwości wyboru, lista jest pusta...");
                Console.ReadLine();
            }
            else
            {
                Console.Write("Twój wybór: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                tasks[choice].GenerateMenu();
            }
        }

        void WorkDaysList()
        {
            if (workDays.Count < 1)
            {
                Console.WriteLine("[brak dni pracy]");
                Console.WriteLine("Brak możliwości wyboru, lista jest pusta...");
                Console.ReadLine();
            }
            else
            {
                int day = 1;
                foreach (WorkDay workDay in workDays)
                {
                    Console.WriteLine(day + ". " + workDay.name + " " + workDay.startDate + "-" + workDay.endDate);
                    day++;
                }
            }
        }

        void WorkPlan()
        {
            Console.WriteLine();

            double workDuration = 15.0;
            double breakDuration = 5.0;

            int dayOfWeek = (int)DateTime.Now.DayOfWeek;
            double timeOfDay = Convert.ToDouble(DateTime.Now.ToString("HH.mm"));

            Console.WriteLine("Plan pracy: ");
            Console.WriteLine("Godzina: " + timeOfDay);

            Console.WriteLine("Dzisiaj " + dayOfWeek + " dzień tygodnia");
            Console.Write("Dzisiaj pracujesz: ");

            if (dayOfWeek > workDays.Count)
                Console.Write("Nie. Dzień wolny");
            else
            {
                double todayStart = workDays[dayOfWeek - 1].startDate;
                double todayEnd = workDays[dayOfWeek - 1].endDate;

                Console.Write(todayStart + "-" + todayEnd + "\n");

                Console.Write("Czas na: ");
                if (todayStart>timeOfDay || todayEnd<timeOfDay)
                {
                    Console.WriteLine("Wolne. Poza godzinami pracy");
                }
                else
                {
                    double remainingWorkTime = todayStart - timeOfDay;
                    double fullWorkPeriods = Math.Floor(remainingWorkTime / (workDuration + breakDuration));

                    if (remainingWorkTime > workDuration)
                    {
                        Console.WriteLine("Jest teraz czas na przerwę.");
                    }
                    else if (fullWorkPeriods % 2 == 0) // Jeśli liczba pełnych okresów pracy jest parzysta
                    {
                        Console.WriteLine("przerwe (5min).");
                    }
                    else
                    {
                        Console.WriteLine("prace (15min).");
                    }
                }
            }

            Console.WriteLine();
        }

        class WorkDay
        {
            public string name;
            // Dodać numer dnia pracy ( 1=poniedziałek, 3=środa, 5=piątek, ...)
            public double startDate;
            public double endDate;

            public WorkDay(int day)
            {
                Console.Write("Podaj nawę " + day + " dnia: ");
                this.name = Console.ReadLine();

                Console.Write("Podaj godzine rozpoczęcia dnia: ");
                this.startDate = Convert.ToDouble(Console.ReadLine());

                Console.Write("Podaj godzine zakończenia dnia: ");
                this.endDate = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Dzień " + day + " dodany..");
                Console.ReadLine();
            }
        }
    }
}
