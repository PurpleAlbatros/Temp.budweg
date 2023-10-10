using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudwegMenu
{
    public class WorkStation
    {
        public string Title { get; set; }

        private string zone;
        public string Zone
        {
            get { return zone; }
            set
            {
                int zoneValue;
                if (int.TryParse(value, out zoneValue) && zoneValue >= 1 && zoneValue <= 3)
                {
                    zone = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "zone skal være imellem 1 og 3");
                }
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set {name = value; }
        }
















    }


}

