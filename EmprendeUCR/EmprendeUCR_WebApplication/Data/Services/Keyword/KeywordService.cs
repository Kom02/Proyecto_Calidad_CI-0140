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
    public class KeywordService : PageModel
    {
        //Public
        private List<string> keywordNames;
        public string Title;
        public int Id;

        //Private
        private readonly Contexts.SqlServerDbContext _context;

        public KeywordService(Contexts.SqlServerDbContext context)
        {
            keywordNames = new();
            _context = context;
        }

        public async Task<IList<Keywords>> GetAsync()
        {
            return await _context.Keyword.ToListAsync();
        }

        public Keywords getKeyword(string title)
        {
            return _context.Keyword.Find(title);
        }

        public string? GetKeywordTitleById(int Id)
        {
            string title = null;
            Keywords keywords = _context.Keyword.Find(Id);
            if (keywords != null)
                title = keywords.Title;
            return title;
        }
        public async Task<int> addKeyWordToProduct(int productID, string entrepreneurEmail, int categoryID)
        {
            for (int i=0; i<keywordNames.Length()  ; i++)
            {
                var keyword = _context.Keyword.FirstOrDefault(k => k.Title.Equals(keywordNames[i]));
                if (keyword != null)
                {
                    Has_Keyword has_Keyword = new();
                    has_Keyword.Keyword_ID = keyword.Id;
                    has_Keyword.Product_Category_ID = categoryID;
                    has_Keyword.Product_Entrepreneur_Email = entrepreneurEmail;
                    has_Keyword.Product_ID = productID;
                    await _context.Has_Keyword.AddAsync(has_Keyword);
                    await _context.SaveChangesAsync();
                }
            }
            keywordNames.Clear();
            return 1;
        }

        public void addToList(string keywordName)
        {
            if (keywordName != null)
            {
                keywordNames.Add(keywordName);
            }
        }

        public async Task<bool> InsertKeyword(string keywordName)
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
