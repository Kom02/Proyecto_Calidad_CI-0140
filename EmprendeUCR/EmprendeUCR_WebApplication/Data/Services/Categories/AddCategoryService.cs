using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmprendeUCR_WebApplication.Data.Entities;
using Syncfusion.Blazor.TreeGrid;
using Syncfusion.Blazor.Grids;

namespace EmprendeUCR_WebApplication.Data.Services.Categories
{
    public class AddCategoryService : PageModel
    {
        public AddCategoryService(Contexts.SqlServerDbContext context)
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
        private SfTreeGrid<Category> TreeGrid;
        private SfGrid<Category> Grid;
        private bool TitleDadNotValid;
        private bool TitleNotValid;
        private Category SelectedCategory;
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
        public void OpenAddCategoryDialog(Category category)
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

        public async void AddCategory(SfTreeGrid<Category> main)
        {
            this.TreeGrid = main;
            this.AddDialogVisible = false;
            Category Category = new Category();

            Category.Title = Title;
            Category.Description = Description;
            Console.WriteLine(ParentID);
            if (ParentID != null)
            {
                Category.ParentId = int.Parse(ParentID);
            }
            await InsertCategoryAsync(Category);
            var ParentIDIndex = TreeGrid.GetRowIndexByPrimaryKey(Category.ParentId).Result;
            if (ParentIDIndex < 0)
            {
                await this.TreeGrid.AddRecord(Category, 0, RowPosition.Top);
            }
            else
            {
                await this.TreeGrid.AddRecord(Category, ParentIDIndex, RowPosition.Child);
            }
            ResetAddCategoryData();
        }
        public async void AddCategoryG()
        {
            this.AddDialogVisible = false;
            Category Category = new Category();

            Category.Title = Title;
            Category.Description = Description;
            Console.WriteLine(ParentID);
            if (ParentID != null)
            {
                Category.ParentId = int.Parse(ParentID);
            }
            await InsertCategoryAsync(Category);
            ResetAddCategoryData();
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
        public async Task<bool> InsertCategoryAsync(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        }

        //Refresh Interface
    }
}
