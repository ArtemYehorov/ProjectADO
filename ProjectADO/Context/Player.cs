
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectADO.Context
{
    public class Player
    {
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public String Surname { get; set; } = null!;
        public String Patronymic { get; set; } = null!;
        public int Age { get; set; }
        public int IdTeam { get; set; }

        public String ToShortString()
        {
            return Id.ToString() + " " + Name + " " + Surname + " " + Patronymic + " " + Age + " - Лет";
        }


    }
}
 