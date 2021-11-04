using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmprendeUCR.Domain.Core.Entities;
using EmprendeUCR.Domain.Categories.Entities;

namespace EmprendeUCR.Domain.Entrepreneurs.Entities.Product_Services
{
    public class Product_Service
    {
        public int Code_ID { get; set; }
        public Category Category { get; set; }
        //public string Description { get;set }
        //public Entrepreneur Entrepreneur { get; set; }
        //public Category Category { get; set; }
        //public Boolean Availability { get; set; }

        //private readonly List<Status> _statuses;

        //public Product_Service(Entrepreneur entrepreneur, Category category, Boolean availability)
        //{
        //    Entrepreneur = entrepreneur;
        //    Category = category;
        //    Availability = availability;
        //}


        // for EFCore
        private Product_Service()
        {
            Code_ID = 0;
            Category = null;
            //Entrepreneur = null!;
            //Category = null!;
            //Availability = true!;
        }


        //public void AddPlayerToRoster(Player player)
        //{
        //    if (_roster.Count >= MaxRosterSize)
        //        throw new DomainException("Roster is at it's maximum capacity.");

        //    if (_roster.Exists(p => p == player))
        //        throw new DomainException("Player is already in the team.");

        //    if (_roster.Exists(p => p.JerseyNumber == player.JerseyNumber))
        //        throw new DomainException(
        //            "A player with the selected jersey number is already registered in the team.");

        //    _roster.Add(player);
        //    player.AssignTeam(this);
        //}

        //public void RemovePlayerFromRoster(Player player)
        //{
        //    if (_roster.Exists(p => p == player))
        //    {
        //        _roster.Remove(player);
        //        player.AssignTeam(null);
        //    }
        //}

    }
}