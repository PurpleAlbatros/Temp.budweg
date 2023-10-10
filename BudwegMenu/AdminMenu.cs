using System;
using System.Runtime.CompilerServices;

namespace BudwegMenu
{
    public class AdminMenu
    {
        public void AdminMenuShow()
        {
            bool menuRunning = true;

            while (menuRunning)
            {
                Console.Clear();
                Console.WriteLine("\nAdmin Menu.\n");
                Console.WriteLine("1. Vis medarbejderliste");
                Console.WriteLine("2. Opret ny medarbejder");
                Console.WriteLine("3. Tilbage til hovedmenuen");
                Console.Write("Indsæt valg: ");

                int AdminChoice = int.Parse(Console.ReadLine());
                if (AdminChoice == 1)
                {
                    EmployeeList list = new EmployeeList();
                    list.EmployeeListShow();
                }
                else if (AdminChoice == 2)
                {
                 Create_UserID_and_saves create = new Create_UserID_and_saves();
                    create.show2();
                }
                else if (AdminChoice == 3)
                {
                    menuRunning = false;
                }
            } 
        }

        public void adminMenu() // opsætning af kodebeskyttelse af menuen
        {
            string correctUsername = "admin";
            string correctPassword = "1234";
            int attempts = 3;
            Console.Clear();
            Console.WriteLine("Indtast venligst administrator id og kodeord.");

            while (attempts > 0)
            {
                Console.Write("Brugernavn: ");
                string enteredUsername = Console.ReadLine();
                Console.Write("Adgangskode: ");
                
                string enteredPassword = "";
                
                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true); // Dette gør den indtastede kode maskeret

                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        enteredPassword += key.KeyChar;
                        Console.Write("*");
                    }
                    else if (key.Key == ConsoleKey.Backspace && enteredPassword.Length > 0)
                    {
                        enteredPassword = enteredPassword.Substring(0, enteredPassword.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                while (key.Key != ConsoleKey.Enter);

                if (enteredUsername == correctUsername && enteredPassword == correctPassword) 
                {
                    Console.WriteLine("Succesfuldt login!");
                    AdminMenu adminMenu = new AdminMenu();
                    adminMenu.AdminMenuShow();
                    break;
                }
                else
                {
                    attempts--;
                    Console.WriteLine();
                    Console.WriteLine($"Forkert brugernavn eller adgangskode. Du har {attempts} forsøg tilbage.");
                }
            }

            if (attempts == 0)
            {
                
                Console.WriteLine("For mange login forsøg, du sendes tilbage til hovedmenuen.");
                Console.WriteLine("Tryk på en vilkårlig tast");
                Console.ReadLine();
            }

        }

        
    }
}
