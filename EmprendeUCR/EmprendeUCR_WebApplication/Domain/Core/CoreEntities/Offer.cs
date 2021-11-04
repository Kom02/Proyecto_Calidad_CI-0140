
using EmprendeUCR_WebApplication.Domain.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace EmprendeUCR_WebApplication.Domain.Core.CoreEntities
{
    public partial class Offer : AggregateRoot
    {

        public int OfferId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string OfferDescription { get; set; }
        public int Discount { get; set; }
        private readonly List<IsOffer> _isOffers;

        public virtual IReadOnlyCollection<IsOffer> IsOffers => _isOffers.AsReadOnly();


    }
}
