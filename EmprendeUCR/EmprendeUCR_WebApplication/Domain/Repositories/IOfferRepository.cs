
using EmprendeUCR_WebApplication.Domain.Core.CoreEntities;
using EmprendeUCR_WebApplication.Domain.Core.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/* This file is used as a interface of the file OfferRepository.
 */
namespace EmprendeUCR_WebApplication.Domain.Repositories
{

    public interface IOfferRepository : IRepository<Offer>
    {
        Task<List<Offer>> getOffersToShop(DateTime dateTime);
        List<Offer> getOffersToOrder(DateTime dateTime);
    }
}
