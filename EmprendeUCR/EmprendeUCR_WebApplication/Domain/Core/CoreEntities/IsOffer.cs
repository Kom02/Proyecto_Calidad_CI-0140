using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EmprendeUCR_WebApplication.Domain.Core.CoreEntities
{
    public partial class IsOffer
    {
        [Key]
        public int OfferId { get; set; }
        public int CodeId { get; set; }
        public string UserEmail { get; set; }
        public int CategoryId { get; set; }
        public int? Amount { get; set; }

        public virtual Offer Offer { get; set; }

        internal bool apply(Product product)
        {
            return
               product.CodeId == CodeId && product.EntrepreneurEmail == UserEmail
               && product.CategoryId == CategoryId ? true : false;
        }
    }
}
