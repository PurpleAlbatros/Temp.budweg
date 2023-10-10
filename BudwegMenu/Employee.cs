using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace BudwegMenu
{
    public class Employee
    {
        public string Title { get; set; }
        public WorkStation[] MenuChoice { get; set; }
        public int ItemCount { get; set; }


        private string firstName;
        private string lastName;
        private int skills;
        private string zone;
        private string id; // bliver ikke brugt endnu
        private string Password; // bliver ikke brugt endnu
        private WorkStation workStation;
        internal string Zone;
        internal string Arbejdsstation;

        public string ID
        {
            get { return id; }



        }



        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length > 0)
                {
                    firstName = value;
                }
                else
                {
                    throw new Exception("Ugyldigt navn");
                }

            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length > 0)
                {
                    lastName = value;
                }
                else
                {
                    throw new Exception("Ugyldigt navn");
                }

            }
        }
        public int Skills
        {
            get { return skills; }
            set
            {
                if (value > 0)
                {
                    skills = value;
                }
                else
                {
                    throw new Exception("Ugyldig kompetenceniveau");
                }
            }

        }









        public WorkStation WorkStation { get => workStation; set => workStation = value; }
        public string LoginName { get; internal set; }
        public DateTime TjekkedIndTid { get; internal set; }

        public Employee() { }
        public Employee(string F, string L, int S, string z)
        {
            FirstName = F;
            LastName = L;
            Skills = S;

        }

        public Employee(string FirstName, string LastName, WorkStation workStation, DateTime time)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.WorkStation = workStation;
            this.TjekkedIndTid = time;

        }

        public Employee(string firstName, string lastName, string id)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
        }

        public string employeedata()
        {
            return firstName + " ," + lastName + "," + skills;
        }
        public string statustrapport()
        {
            return firstName + " " + lastName;
        }


        public void Show()
        {
            Console.WriteLine(Title);
            for (int i = 0; i < ItemCount; i++)
            {
                Console.WriteLine(MenuChoice[i].Title);
            }
        }

    }
}