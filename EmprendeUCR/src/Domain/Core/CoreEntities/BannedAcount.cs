using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class BannedAcount
    {
        public string UserEmail {get; set;}
        public DateTime BeginDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int Type { get; set; }

    }
}
