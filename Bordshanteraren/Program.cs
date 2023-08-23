namespace Bordshanteraren
{
    internal class Program
    {
        static void Filhantering() //P2.1
        {

           while (true)
            {
                Console.WriteLine("Do you want to [C]reate/overwrite, [R]ead from file or [Q]uit");
                string choice = Console.ReadLine();

                if (choice == "C")
                {
                    Console.Write("Choose file to create/overwrite: ");
                    string fileName = Console.ReadLine();

                    Console.Write("Please write what you want to put in the file: ");
                    string fileContents = Console.ReadLine();

                    File.WriteAllText(fileName, fileContents);
                }
                else if (choice == "Q")
                {
                    return;
                }
                else
                {
                    Console.Write("Choose file to read: ");
                    string fileName = Console.ReadLine();

                    if (File.Exists(fileName))
                    {
                        Console.WriteLine($"Printing the contents of {fileName}: ");
                        string[] fileContents = File.ReadAllLines(fileName);
                        foreach (string line in fileContents)
                        {
                            Console.WriteLine($"{line}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No file with that name exists :(");
                    }
                }
            }
            
            
        }

        static void Bordshantering()
        {
            Console.WriteLine("Welcome to the seating management system!");
            string[] tables;
            string[] tableTemplate = new string[8] { "", "", "", "", "", "", "", "" };

            if (File.Exists("TABLES"))
            {
                tables = File.ReadAllLines("TABLES");
                Console.WriteLine("File found, information loaded");
            }
            else
            {
                File.WriteAllLines("TABLES", tableTemplate);
                Console.WriteLine("No file found, new template created");
                tables = tableTemplate;
            }

            Console.WriteLine("Please choose a option from the menu: ");
            Console.WriteLine("1. Show all tables");
            Console.WriteLine("2. Add/Change table information");
            Console.WriteLine("3. Clear a table");
            Console.WriteLine("4. Quit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    for (int i = 1; i < 9; i++)
                    {
                        Console.WriteLine($"Table number {i}: {tables[i - 1]} ");
                    }
                    break;

                case 2:
                    Console.WriteLine("Please input which table you want to edit: ");
                    int tableNumber = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"Table {tableNumber} information: ");
                    string userInput = Console.ReadLine();

                    tables[tableNumber] = userInput;
                    break;

                case 3:
                    Console.WriteLine("Please input which table you wish to clear: ");
                    int userChoice = Convert.ToInt32(Console.ReadLine());
                    tables[userChoice] = "";
                    break;

                case 4:
                    File.WriteAllLines("TABLES", tables);
                    Console.WriteLine("Tables have been saved, see you next time!");
                    return;

                default:
                    Console.WriteLine("Your input was invalid!, Try again");
                    break;
            }
        }
        
        static void Main(string[] args)
        {
            Bordshantering();
        }
    }
}