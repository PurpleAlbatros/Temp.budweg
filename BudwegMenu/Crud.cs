using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BudwegMenu
{
    public class Create_UserID_and_saves

    {
        public static void tjekInd(string loginName, string firstName, string lastName, string zone, string Arbejdsstation, DateTime time)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("TjekInd.txt", true)) // Use "true" to append to the file
                {
                    writer.WriteLine($"{loginName} {firstName} {lastName} {zone} {Arbejdsstation} {time}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while writing to the file: " + e.Message);
            }
        }
    
        









            public static void TjekUd(string employeeID)
            {
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
        public static Employee? findUser(string employeeID)
            {
                try
                {
                    string[] lines = File.ReadAllLines("TjekInd.txt");
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length >= 5 && parts[0] == employeeID)
                        {
                        WorkStation test;
                        new WorkStation();


                        WorkStation workStation = new WorkStation();
                        workStation.Zone = parts[5];
                        workStation.Name = parts[6];

                        return new Employee
                        {

                            FirstName = parts[2],
                            LastName = parts[4],
                            WorkStation = workStation,
                                Arbejdsstation = parts[5],
                                TjekkedIndTid = DateTime.Parse($"{parts[7]} {parts[8]}")
                            };
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occurred while reading the file: " + e.Message);
                }

                return null; // Employee not found

            }
 public void show2()
        {

         
        

            Console.WriteLine("Opret ny medarbejder ");

            Console.Write("Fornavn: ");
            string firstName = Console.ReadLine();
            Console.Write("Efternavn: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("vælg venligst kompetenceniveaue.");
            Console.WriteLine("du kan vælge imllem 5 niveauer (1= nybegynder . 2= lidt erfaren . 3= en del erfaren . 4= meget erfaren . 5= mest erfaring ");

            string newEmployee = Console.ReadLine(); ; // Du kan tilføje flere oplysninger om den nye medarbejder her
            string Arbejdsstation;
            // Opret bruger-ID ved at tage de første bogstaver i fornavn og efternavn
            string initials = (firstName.Length > 0 ? firstName.Substring(0, 1) : "") +
                              (lastName.Length > 0 ? lastName.Substring(0, 1) : "") +
                              "1234";

            Console.WriteLine($"\n Du har oprettet en ny medarbejder:\n");
            Console.WriteLine($"Fornavn: {firstName}");
            Console.WriteLine($"Efternavn: {lastName}");
            Console.WriteLine($"Færdigheder: {newEmployee}");
            Console.WriteLine($"Bruger-ID: {initials}\n");

            // Gem data i en fil eller en database, afhængigt af dine behov
            using (StreamWriter writer = new StreamWriter("BrugerID.txt", true))
            {
                writer.WriteLine($"Fornavn: {firstName}: Efternavn: {lastName}: Kompetenceniveau: {newEmployee}: Bruger-ID {initials}: ");
                
                writer.WriteLine(); // Tom linje for at adskille dataene

            }

            Console.WriteLine("Informationen er blevet gemt");
            Console.WriteLine("Tryk på en vilkårlig tast for at vende tilbage til menuen.");
            Console.ReadKey(); // Brug ReadKey i stedet for ReadLine for at vente på en tastetryk


        }

        }
       
       
    }

