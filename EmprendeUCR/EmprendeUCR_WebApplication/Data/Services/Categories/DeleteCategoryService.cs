using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmprendeUCR_WebApplication.Data.Entities;
using Syncfusion.Blazor.TreeGrid;
using EmprendeUCR_WebApplication.Data.Services;

namespace EmprendeUCR_WebApplication.Data.Services.Categories
{
    public class DeleteCategoryService : PageModel
    {
        private readonly Contexts.SqlServerDbContext _context;
        SfTreeGrid<Category> TreeGrid;
        public DeleteCategoryService(Contexts.SqlServerDbContext context)
        {
            ResetRemoveCategoryData();
            _context = context;
        }
        /*
         * 
         * Private Variables
         * 
         */
        Product_ServiceService p_s_service;
        private bool deleted = false;
        private int SelectedId = -1;
        private Category SelectedCategory;

        /*
         * 
         * Public Variables
         * 
         */
        public bool deleteNotValid = false;
        public string Title = null;
        public bool RemoveDialogVisible;
        public bool RemoveToolbarItemDisabled;
        /*
         * 
         * Testing
         * 
         */
        public double SelectedIndex;
        public void OpenRemoveCategoryDialog(Category category)
        {
            this.SelectedCategory = category;
            this.RemoveDialogVisible = true;
            this.SelectedId = SelectedCategory.Id;
            this.Title = SelectedCategory.Title;
        }
        public void CloseRemoveCategoryDialog()
        {
            this.RemoveDialogVisible = false;
            ResetRemoveCategoryData();
        }

        public void ResetRemoveCategoryData()
        {
            deleteNotValid = false;
            deleted = false;
            RemoveToolbarItemDisabled = true;
            Title = null;
            SelectedId = -1;
        }

        public async void RemoveCategory(SfTreeGrid<Category> main)
        {
            this.TreeGrid = main;
            this.RemoveDialogVisible = false;
            RemoveCategory(SelectedId);
            if (!deleted)
            {
                var SelectedIndex = await TreeGrid.GetRowIndexByPrimaryKey(SelectedCategory.Id);
                await TreeGrid.DeleteRecord("Nombre", SelectedCategory);
            }
        }
        public void RemoveCategory(int Id)
        {
            RemoveCategoryRecursive(Id);
            
        }
        public void RemoveCategoryRecursive(int Id)
        {
            IList<Category> listChilds =_context.Category.Where(c => c.ParentId.Equals(Id)).ToList();
            foreach(Category category in listChilds)
            {
                if (AnyProductsServicesAssociate(category.Id) && (!deleted))
                {
                    RemoveCategoryRecursive(category.Id);
                }
                else
                {
                    deleted = true;
                }
            }
            if (!AnyProductsServicesAssociate(Id))
            {
                deleted = true;
            }
            if (!deleted)
            {
                Category CategoryToRemove = _context.Category.Find(Id);
                _context.Category.Remove(CategoryToRemove);
                _context.SaveChanges();
                TreeGrid.DeleteRecord(Title, SelectedCategory);
            }
            if (deleted)
            {
                deleteNotValid = true;
            }
            
        }
        public bool AnyProductsServicesAssociate(int categoryId)
        {
            bool any = true;
            var products = _context.Product_Service.Where(p => p.Category_ID.Equals(categoryId)).ToList().Length();
            Console.WriteLine("Productos asociados ");
            Console.WriteLine(products);
            if (products != 0)
            {
                any = false;
            }
            return any;
        }
    }
}
