using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmprendeUCR_WebApplication.Data.Services
{
	public class LikesService : PageModel
	{
		private readonly EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext _context;

		public LikesService(EmprendeUCR_WebApplication.Data.Contexts.SqlServerDbContext context)
		{
			_context = context;
		}

		public async Task<IList<Likes>> GetAsync()
        {
            return await _context.Likes.ToListAsync();
        }

		public void AddLikes(Likes likes)
		{
			_context.Likes.Add(likes);
			_context.SaveChanges();
		}

        public void RemoveLikes(Likes likes)
        {
            _context.Likes.Remove(likes);
            _context.SaveChanges();
        }

		public async Task<IList<Likes>> GetByEmailAsync(string email)
		{
			return await _context.Likes.Where(c => String.Equals(c.Members_Email, email)).ToListAsync();
		}
	}
}