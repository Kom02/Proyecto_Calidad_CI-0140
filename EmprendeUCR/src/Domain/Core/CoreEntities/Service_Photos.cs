

namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class Service_Photos
    {
        public int Service_Photos_ID { get; set; }

        public int Code_ID { get; set; }

        public byte[] Photos { get; set; }

        public string Entrepreneur_Email { get; set; }

        //FK
        public int Category_ID { get; set; }
    }
}
