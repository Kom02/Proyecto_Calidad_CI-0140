using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmprendeUCR_WebApplication.Data;
using EmprendeUCR_WebApplication.Data.Entities.ContextShop;

namespace EmprendeUCR_WebApplication.Data.Services
{
    
    public class Alliance_Service: PageModel
    {
        private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;


        public Alliance_Service(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context) {
            _context = context;
        }


        public async Task<IList<Alliance>> GetAsync()    // Enlista Alianzas 
        {
            return await _context.Alliance.ToListAsync();
        }


        public async Task<bool> InsertAllianceServiceAsync(Alliance alliance) // Agrega Alianzas
        {

            Alliance obj = alliance;
            await _context.Alliance.AddAsync(obj);
            await _context.SaveChangesAsync();
            Console.WriteLine(obj);
            return true;
        }

        public void delete_Alliace(Alliance alliance) {
            _context.Alliance.Remove(alliance);
            _context.SaveChanges();
        }

        public void updateAlliance(Alliance alliance, int new_status)
        {
            alliance.Alliance_Status = new_status;
            _context.SaveChanges();
        }

        public List<Alliance> getAlliancesByEntrepreneurEmail(string email)
        {
            return _context.Alliance.Where(otherEntrepreneur => String.Equals(otherEntrepreneur.User_Email, email) || String.Equals(otherEntrepreneur.Ally_User_Email, email)).ToList();
        }


        public List<Alliance> getAlliancesByEntrepreneurEmailAndStatus(string email, int status)
        {
            return _context.Alliance.Where(otherEntrepreneur => (String.Equals(otherEntrepreneur.User_Email, email) || String.Equals(otherEntrepreneur.Ally_User_Email, email)) && otherEntrepreneur.Alliance_Status == status).ToList();
        }

    }
}