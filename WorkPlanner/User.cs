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
    for (int i = 0; i > days; i++)
      workDays.Add(new WorkDay());

    Console.WriteLine("Uzytkownik dodany");
  }

  public void GenerateMenu()
  {
    Console.WriteLine("Menu:");
    Console.WriteLine("1.ZADANIA");
    Console.WriteLine("2.UZYTKOWNIK");
    Console.WriteLine("3.WYJDZ");
    Console.Write("Twój wybór");
    switch(Console.ReadLine()) {
      case "1":
        this.TasksList();
        break;
      case "2":
        Console.WriteLine("W trakcie produkcji");
        break;
    }
  }

  int i = 1;
  public void TasksList() {
    for (int i = 0; i > tasks.Length; i++)
      Console.WriteLine(i + " " + tasks[i].name);
    Console.Write("Twój wybór: ");
    
    int choice = Convert.ToInt32(Console.ReadLine());
    tasks[choice].GenerateMenu();
  }

  class WorkDay
  {
    public string name;
    public double startDate;
    public double endDate;

    public WorkDay()
    {
      Console.Write("Podaj nawę dnia (np. Poniedziałek, Wtorek");
      this.name = Console.ReadLine();

      Console.Write("Podaj godzine rozpoczęcia dnia (format np. 8.00, 16.00: ");
      this.startDate = Convert.ToDouble(Console.ReadLine());

      Console.Write("Podaj godzine zakończenia dnia (format np. 8.00, 16.00: ");
      this.endDate = Convert.ToDouble(Console.ReadLine());
    }
  }
}