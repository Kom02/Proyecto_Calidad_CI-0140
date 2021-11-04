using System;

namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class ActiveAdministrators
    {
        public string Email { get; set; }
        public DateTime Creation_Date { get; set; }
        public bool Response { get; set; }
        public bool Confirm { get; set; }
        public bool Active { get; set; }
        public DateTime Response_Date { get; set; }
    }
}
