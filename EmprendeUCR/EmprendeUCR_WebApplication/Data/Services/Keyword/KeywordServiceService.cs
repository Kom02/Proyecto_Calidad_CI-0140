using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using EmprendeUCR_WebApplication.Data.Entities.Keyword;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.TreeGrid;

namespace EmprendeUCR_WebApplication.Data.Services.Keyword
{
    public class KeywordServiceService : PageModel
    {
        //Public
        public string Title;
        public int Id;

        //Private
        private List<string> keywordNames;
        private readonly Contexts.SqlServerDbContext _context;

        public KeywordServiceService(Contexts.SqlServerDbContext context)
        {
            keywordNames = new();
            _context = context;
        }
        public async Task<IList<Keywords>> GetAsync()
        {
            return await _context.Keyword.ToListAsync();
        }

        public Keywords getKeywordService(string title)
        {
            return _context.Keyword.Find(title);
        }

        public async Task<int> addKeyWordToService(int serviceID, string entrepreneurEmail, int categoryID)
        {
            for (int i = 0; i < keywordNames.Length(); i++)
            {
                var keyword = _context.Keyword.FirstOrDefault(k => k.Title.Equals(keywordNames[i]));
                if (keyword != null)
                {
                    Has_Keyword_Service has_Keyword = new();
                    has_Keyword.Keyword_ID = keyword.Id;
                    has_Keyword.Service_Category_ID = categoryID;
                    has_Keyword.Service_Entrepreneur_Email = entrepreneurEmail;
                    has_Keyword.Service_ID = serviceID;
                    await _context.Has_Keyword_Service.AddAsync(has_Keyword);
                    await _context.SaveChangesAsync();
                }
            }
            keywordNames.Clear();
            return 1;
        }

        public void addToListService(string keywordName)
        {
            if (keywordName != null)
            {
                keywordNames.Add(keywordName);
            }
        }

        public async Task<bool> InsertKeywordService(string keywordName)
        {
            if (keywordName == null)
            {
                return false;
            }
            else
            {
                if (keywordName != "")
                {
                    var exists = _context.Keyword.Where(k => k.Title.Equals(keywordName));
                    if (exists.ToList().Length() == 0)
                    {
                        Keywords keyword = new();
                        keyword.Title = keywordName;
                        await _context.Keyword.AddAsync(keyword);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
