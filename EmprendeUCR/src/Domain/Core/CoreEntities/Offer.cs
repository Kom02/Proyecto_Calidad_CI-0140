using System;
namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class Offer
    {
        public int Offer_ID { get; set; }
        public DateTime Initial_Date { get; set; }
        public DateTime Expire_Date { get; set; }
        public string Offer_Description { get; set; }
        public int Discount { get; set; }

    }
}
