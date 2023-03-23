using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectADO.Context
{
    public class Сoach
    {
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public String Surname { get; set; } = null!;
        public int Age { get; set; }
        public int IdCountry { get; set; }
        public String ToShortString()
        {
            return Id.ToString() + " " + Name + " " + Surname + " " + Age;
        }
    }
}
