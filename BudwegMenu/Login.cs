using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudwegMenu
{
    internal class Login
    {
        public string GetZoneInput()
        {
            Console.Write("Indtast venligst zone: ");
            return Console.ReadLine();
        }

        public string GetNameInput()
        {
            Console.Write("Indtast venligst navn: ");
            return Console.ReadLine();
        }

        public void login()
        {

            Console.WriteLine("Indtast dit brugerID: ");

            string loginName = Console.ReadLine();
            Employee? foundUser = ValidateUser(loginName);
            Create_UserID_and_saves.findUser(loginName);
            Employee? employee = Create_UserID_and_saves.findUser(loginName);
            if (employee != null)
            {
             Console.WriteLine($" Du er allerede logget ind her {employee.WorkStation.Name} {employee.WorkStation.Zone} du er nød til at logge ud først ");
                return;
            }
            foundUser.WorkStation = new WorkStation();

            if (foundUser != null)
            {

                Console.WriteLine($"Hej {foundUser.FirstName}, du er nu logget ind ");
                Console.WriteLine("Vælg venligst din arbejdsstation");

                Console.WriteLine();
                foundUser.WorkStation.Zone = GetUserZoneInput();
                foundUser.WorkStation.Name = GetUserArbejdsstionsInput();
                Create_UserID_and_saves.tjekInd(loginName,foundUser.FirstName,foundUser.LastName,foundUser.WorkStation.Zone, foundUser.WorkStation.Name,DateTime.UtcNow);

              
            }
            else
            {
                Console.WriteLine("Ugyldigt Bruger-ID. Log ind mislykkedes.");
                Console.ReadLine();
            }

            {


            }
        }
        

        private Employee? ValidateUser(string employeeID)
        {
            using (StreamReader reader = new StreamReader("BrugerID.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains($"Bruger-ID {employeeID}:"))
                    {
                        string[] parts = line.Split(':');
                        string firstName = parts[1];
                        string lastName = parts[3];
                        //splitet data, til strings
                        //tag string fornavn og efternavn
                        Employee employee = new Employee(firstName, lastName, employeeID);
                        return employee;
                    }
                }
            }

            // Hvis Bruger-ID'en ikke blev fundet, returnerer vi false i en else-blok
            return null; // Bruger-ID'en blev ikke fundet, så brugeren er ugyldig
        }


        private string GetUserZoneInput()
        {
            string zoneInput = "";
            while (true)
            {
                Console.Write("Vælg venligst blandt Zone 1-3: ");
                zoneInput = Console.ReadLine();
                if (int.TryParse(zoneInput, out int inputValue))
                {
                    if (inputValue >= 1 && inputValue <= 3)
                    {
                        
                        
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ugyldigt valg. Prøv igen."); 
                    }
                }
                else
                {
                    Console.WriteLine("Ugyldig indtastning. Indtast et gyldigt nummer.");
                }
            }

            // Add a default return statement to satisfy the compiler
            return zoneInput; // You can return an empty string or any other suitable default value
        }
        public static void RemoveEmployee(string employeeID)
        {
            string loginName= Console.ReadLine();
            string inputFile = "TjekInd.txt";
            string tempFile = "temp.txt";

            try
            {
                string[] lines = File.ReadAllLines(inputFile);

                using (StreamWriter writer = new StreamWriter(tempFile))
                {
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length >= 8 && parts[0] != employeeID)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }

                File.Delete(inputFile);
                File.Move(tempFile, inputFile);

                Console.WriteLine($"Employee with ID '{employeeID}' has been removed.");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while updating the file: " + e.Message);
            }
        }

        private string GetUserArbejdsstionsInput()
        {
            string arbejdsstationsInput = "";
            while (true)
            {
                Console.Write("Vælg venligst blandt arbejdsstation 1-18: ");
                arbejdsstationsInput = Console.ReadLine();
                if (int.TryParse(arbejdsstationsInput, out int inputValue))
                {
                    if (inputValue >= 1 && inputValue <= 18)
                    {
                        
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ugyldigt valg. Prøv igen.");
                    }
                }
                else
                {
                    Console.WriteLine("Ugyldig indtastning. Indtast et gyldigt nummer.");
                }
            }

            // Add a default return statement to satisfy the compiler
            return arbejdsstationsInput; // You can return an empty string or any other suitable default value
        }

        
    }
}


