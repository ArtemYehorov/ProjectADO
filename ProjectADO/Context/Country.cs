using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectADO.Context
{
    public class Country
    {
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public String ToShortString()
        {
            return Id.ToString() + " " + Name;
        }
    }
}
