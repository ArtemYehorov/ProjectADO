
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectADO.Context
{
    public class Teams
    {
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public int IdCountry { get; set; }
        public int IdCoach { get; set; }

        public String ToShortString()
        {
            return Id.ToString()[..4] + " " + Name + " " + IdCountry.ToString() + " " + IdCoach.ToString();
        }

    }
}
