using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace BudwegMenu
{
    public class EmployeeList
    {
        public void EmployeeListShow()
        {
            try
            {
                using StreamReader reader = new StreamReader("tjekInd.txt");

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Closing the file.");
            }
        }

    
            
           
             
            
        
        }
    }




