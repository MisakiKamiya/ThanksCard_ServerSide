using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThanksCard1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int CD { get; set; }
        public string Name { get; set; }
        public string NameKana { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }

        public int KaId { get; set; }
        public virtual Ka Ka { get; set; }
    

    }
}
