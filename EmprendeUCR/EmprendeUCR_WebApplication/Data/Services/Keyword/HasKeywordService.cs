using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities.Keyword;
using EmprendeUCR_WebApplication.Data.Services.Keyword;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmprendeUCR_WebApplication.Data.Services.Keyword
{
    public class HasKeywordService
    {
        private readonly Contexts.SqlServerDbContext _context;
        public HasKeywordService(Contexts.SqlServerDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Has_Keyword>> GetAsync()
        {
            return await _context.Has_Keyword.ToListAsync();
        }
        public List<string> GetKeywordsByProduct(Product product)
        {
            List<string> keywordsTitles = new();
            List<Has_Keyword> has_Keywords = _context.Has_Keyword.Where(hk => hk.Product_ID == product.Code_ID).ToList();
            if (has_Keywords.Count() > 0)
            {
                KeywordService keywordService = new KeywordService(_context);
                foreach (var has_Keyword in has_Keywords)
                {
                    keywordsTitles.Add(keywordService.GetKeywordTitleById(has_Keyword.Keyword_ID));
                }
            }
            return keywordsTitles;
        }
    }
}
