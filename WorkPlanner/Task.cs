public class Task {
  public string name;
  public double price;
  public DateTime startDate;
  public DateTime endDate;

  public Task() {
    Console.Write("Podaj nazwe zadania: ");
    this.name = Console.ReadLine();

    Console.Write("Podaj cene zadania: ");
    this.price = Convert.ToDouble(Console.ReadLine());
  }

  public void GenerateMenu() {
    Console.WriteLine("Menu Zadania:");
    Console.WriteLine("1.Rozpocznij");
    Console.WriteLine("2.Zakoncz");
    Console.WriteLine("3.Raport");
    Console.Write("Twój wybór");
    switch(Console.ReadLine()) {
      case "1":
        this.StartTask();
        break;
      case "2":
        this.EndTask();
        break;
      case "3":
        this.RaportTask();
        break;
    }
  }

  void StartTask() {
    this.startDate = DateTime.Now;
    Console.WriteLine("Zadanie zaczęte");
  }

  void EndTask() {
    this.endDate = DateTime.Now;
    Console.WriteLine("Zadanie zakończone");
  }

  void DisplayTask() {
    Console.WriteLine("Informacje");
    Console.WriteLine("Nazwa: " + this.name);
    Console.WriteLine("Opis: " + this.description);
    Console.WriteLine("Data zaczęcia: " + this.startDate);
    Console.WriteLine("Data zakończenia: " + this.endDate);
    Console.Write("Kliknij aby kontynuować..");
    Console.ReadLine();
  }

  void RaportTask() {
    if(this.endDate) {
      Console.WriteLine("Godziny spędzone: ");
      Console.WriteLine("Płaca: "+this.price);
      Console.WriteLine("Płaca/Godzine: ");
    }
    else {
      Console.WriteLine("Zadanie jeszcze nie zostało zakończone")
    }
  }
}