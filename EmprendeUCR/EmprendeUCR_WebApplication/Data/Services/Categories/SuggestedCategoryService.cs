using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmprendeUCR_WebApplication.Data.Entities;
using Syncfusion.Blazor.TreeGrid;

namespace EmprendeUCR_WebApplication.Data.Services.Categories
{
    public class SuggestedCategoryService : PageModel
    {
        public SuggestedCategoryService(Contexts.SqlServerDbContext context)
        {
            _context = context;
            CategoryService = new(context);
            ResetAddCategoryData();
        }
        /*
         * 
         * Private Variables
         * 
         * 
         */
        private readonly Contexts.SqlServerDbContext _context;
        private CategoryService CategoryService;
        private bool TitleDadNotValid;
        private bool TitleNotValid;
        private Suggested_Category SelectedCategory;
        /*
         * 
         * Private Variables
         * 
         */
        public bool AddDialogVisible;
        public string Title;
        public string ParentID;
        public string Description;
        public bool AddCategoryDisabled;

        /**
         * @brief Open a Popup with the form to add a category name
         * @details the dialog was made with a SfDialog with HTML
         * @param
         * @return
         */
        public void OpenAddCategoryDialog(Suggested_Category category)
        {
            SelectedCategory = category;
            this.AddDialogVisible = true;
        }


        /**
        * @brief Closes the Popup that allows the adding of a new category
        * @details The dialog was made with a SfDialog with HTML
        * @param 
        * @return
        */
        public void CloseAddCategoryDialog()
        {
            this.AddDialogVisible = false;
            ResetAddCategoryData();
        }

        /**
        * @brief Verifies the existance or non existance of a category title
        * @details calls the service ValidateTitle(Title); to do the verification
        * @param args supplies information about a change event, so that the new title can be validated as a non existence name 
        * @return
        */
        public void ValidateTitle(Microsoft.AspNetCore.Components.ChangeEventArgs args)
        {
            TitleNotValid = true;
            Title = (String)args.Value;
            if (Title.Length > 0)
            {
                if (CategoryService.ValidateTitle(Title) == true)
                {
                    TitleNotValid = false;
                }
            }
            AddCategoryDisabled = TitleNotValid || TitleDadNotValid;
        }



        /**
        * @brief Adds a new category to the database and reflects the changes to the site
        * @details calls the service InsertCategoryAsync(Category); to add the category, and getParentId(TitleDad) to get its parent, add category only if the category values are valid
        * @param 
        * @return 
        */
        public async void AddSuggestedCategory()
        {
            this.AddDialogVisible = false;
            Suggested_Category Category = new Suggested_Category();

            Category.Title = Title;
            Category.Description = Description;
            Console.WriteLine(ParentID);
            if (ParentID != null)
            {
                Category.ParentID = int.Parse(ParentID);
            }
            await InsertSuggestedCategoryAsync(Category);
            
            ResetAddCategoryData();
        }
        public void deleteSuggested(Suggested_Category suggested) 
        {
            Suggested_Category CategoryToRemove = _context.Suggested_Category.Find(suggested.ID);
            _context.Suggested_Category.Remove(CategoryToRemove);
            _context.SaveChanges();
        }
        /**
        * @brief Resets all local variables used for adding categories, to their initial state
        * @details all the variables that were set bellow are used for adding categories
        * @param
        * @return
        */
        public void ResetAddCategoryData()
        {
            TitleDadNotValid = false;
            TitleNotValid = true;
            Description = null;
            Title = null;
            ParentID = null;
            AddCategoryDisabled = true;
            SelectedCategory = null;
        }

        /**
        * @brief Inserts a new category in the databased
        * @param Category of type category, that will be inserted in the database
        * @return Task<bool>, depends if the action could be made
        */
        public async Task<bool> InsertSuggestedCategoryAsync(Suggested_Category category)
        {
            await _context.Suggested_Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IList<Suggested_Category>> GetAsync()
        {
            return await _context.Suggested_Category.ToListAsync();
        }
        public Suggested_Category getSuggestedById(int Id)
        {
            return _context.Suggested_Category.Find(Id);
        }
        //Refresh Interface
    }
}