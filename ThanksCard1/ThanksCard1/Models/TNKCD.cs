using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThanksCard1.Models
{
    public class TNKCD
    {
        public int Id { get; set; }
        public int CD { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateHelp { get; set; }
        public int? EmployeeToId { get; set; }
        public virtual Employee EmployeeTo { get; set; }
        public int? EmployeeFromId { get; set; }
        public virtual Employee EmployeeFrom { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int? WorkId { get; set; }
        public virtual Work Work { get; set; }
        public bool Look { get; set; }

    }
}
