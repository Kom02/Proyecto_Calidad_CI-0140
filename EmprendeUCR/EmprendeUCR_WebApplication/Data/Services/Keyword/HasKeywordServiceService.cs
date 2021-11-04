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
    public class HasKeywordServiceService
    {
        private readonly Contexts.SqlServerDbContext _context;
        public HasKeywordServiceService(Contexts.SqlServerDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Has_Keyword_Service>> GetAsync()
        {
            return await _context.Has_Keyword_Service.ToListAsync();
        }
        public List<string> GetKeywordsByService(Service service)
        {
            List<string> keywordsTitles = new();
            List<Has_Keyword_Service> has_Keywords = _context.Has_Keyword_Service.Where(hk => hk.Service_ID == service.Code_ID).ToList();
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
