using System;


namespace EmprendeUCR.Domain.Core.CoreEntities
{
    public class Is_Offer
    {
        public int Offer_ID { get; set; }

         public int Code_ID { get; set; }

        public string User_Email { get; set; }

        public int Category_ID { get; set; }

        public int Amount { get; set; }
    }
}
