using System.ComponentModel.Design.Serialization;

namespace BudwegMenu
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Employee[] medarbejderListe = new Employee[200];
            Employee mainMenu = new Employee();


         

            mainMenu.Title = "BUDWEG MENU\n";
            mainMenu.MenuChoice = new WorkStation[10];

            // First menu item
            WorkStation mi = new WorkStation();
            mi.Title = "1. Log ind  ";
            mainMenu.MenuChoice[0] = mi;
            mainMenu.ItemCount++; 

            // Second menu item
            mi = new WorkStation();
            mi.Title = "2. Log ud   ";
            mainMenu.MenuChoice[1] = mi;
            mainMenu.ItemCount++;

            // Third menu item
            mi = new WorkStation();
            mi.Title = "3. Administrator  ";
            mainMenu.MenuChoice[2] = mi;
            mainMenu.ItemCount++;
            

            // 4th menu item
            mi = new WorkStation();
            mi.Title = "4. Statusrapport ";
            mainMenu.MenuChoice[3] = mi;
            mainMenu.ItemCount++;
           
        string art = @"
 
 /$$$$$$$                  /$$                                        
| $$__  $$                | $$                                        
| $$  \ $$ /$$   /$$  /$$$$$$$ /$$  /$$  /$$  /$$$$$$   /$$$$$$       
| $$$$$$$ | $$  | $$ /$$__  $$| $$ | $$ | $$ /$$__  $$ /$$__  $$      
| $$__  $$| $$  | $$| $$  | $$| $$ | $$ | $$| $$$$$$$$| $$  \ $$      
| $$  \ $$| $$  | $$| $$  | $$| $$ | $$ | $$| $$_____/| $$  | $$      
| $$$$$$$/|  $$$$$$/|  $$$$$$$|  $$$$$/$$$$/|  $$$$$$$|  $$$$$$$      
|_______/  \______/  \_______/ \_____/\___/  \_______/ \____  $$      
                                                       /$$  \ $$      
                                                      |  $$$$$$/      
                                                       \______/       
";

                Console.WriteLine(art);
            
            while (true)
            {

                
        
                mainMenu.Show();
                Console.Write("Indsæt valg: ");
                string valg = Console.ReadLine();

                switch (valg)
                {
                    case "1":
                        // Udfør Sign in handling

                        Console.WriteLine("\nDu har valgt log ind.\n");
                        Login login = new Login();
                        login.login(); // indsæt metode

                        break;

                    case "2":
                        Console.WriteLine("\nDu har valgt log ud.\n");

                        // Prompt the user for the employee ID
                        Console.Write("Enter the Employee ID to remove: ");
                        string employeeID = Console.ReadLine();

                        // Call the RemoveEmployee method with the provided employeeID
                        Login.RemoveEmployee(employeeID);

                        break;

                    case "3":
                        // Udfør andre indstillinger
                        
                        AdminMenu passwordCheck = new AdminMenu();
                        passwordCheck.adminMenu();
                        
                      
                        break;
              
                    case "4":
                        Console.Clear();
                        Console.WriteLine("\nDu har valgt Statusrapport");
                        //EmployeeList status = new EmployeeList();
                        //status.EmployeeListShow();// work in progress mangler at trække kompetence niveau fra
                        try
                        {
                            using (StreamReader sr = new StreamReader("tjekInd.txt"))
                            {
                                string line;

                                // Read and process each line in the file
                                while ((line = sr.ReadLine()) != null)
                                {
                                    string[] opdeltlinje = line.Split(' ');
                                    Console.WriteLine($"Fuldenavn: {opdeltlinje[2]} {opdeltlinje[4]} Zone: {opdeltlinje[5]} Arbejdssattion: {opdeltlinje[6]}  Tjekket ind: {opdeltlinje[7]}-{opdeltlinje[8]}");
                                }
                            }

                        }

                        catch (IOException e)
                        {
                            Console.WriteLine("An error occurred while reading the file: " + e.Message);
                        }

                        Console.ReadLine();

                        break;

                    default:
                        Console.WriteLine("\nUgyldigt valg. Prøv igen.\n");
                        break;

                }
                
                

            }
            Console.Write("Tryk på Enter for at prøve igen ");
            Console.ReadLine();
        }
    }
}
