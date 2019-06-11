using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThanksCard1.Models
{
    public class Ka
    {
        public int Id { get; set; }
        public int CD { get; set; }
        public string KaName { get; set; }
        public int? BusyoId { get; set; }
        public virtual Busyo Busyo { get; set; } 
}

}
