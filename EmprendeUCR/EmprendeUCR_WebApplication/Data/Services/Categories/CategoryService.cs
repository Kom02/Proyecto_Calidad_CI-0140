using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor.TreeGrid;

namespace EmprendeUCR_WebApplication.Data.Services.Categories
{
    public class CategoryService : PageModel
    {
        private readonly Contexts.SqlServerDbContext _context;
        SfTreeGrid<Category> TreeGrid;

        public CategoryService(Contexts.SqlServerDbContext context)
        {
            _context = context;
        }

        /**
        * @brief asyncronously returns a list of the current existing categories
        * @param
        * @return await _context.Category.ToListAsync(), returns the list of existing categories
        */
        public async Task<IList<Category>> GetAsync()
        {
            return await _context.Category.ToListAsync();
        }

        /**
        * @brief Validates if example title of a category isnt already in the categories database
        * @param String param name="title", the title that will be searched in the current list of categories
        * @return bool; true if there isnt already an existing category with the title, else returns false
        */
        public bool ValidateTitle(String title)
        {
            if (_context.Category.Where(c => c.Title.Equals(title)).Count() == 0)
            {
                return true;
            }
            return false;
        }

        public bool ValidateDescription(String description)
        {
            if (_context.Category.Where(c => c.Description.Equals(description)).Count() == 0)
            {
                return true;
            }
            return false;
        }
        /**
        * @brief changes the parent of a category, updates and save the changes
        * @param Title of the actual category and TitleDad of the selected category
        * @return
        */
        public async Task ChangeParent(int Id, int ParentId)
        {
            Category source = await _context.Category.FindAsync(Id);
            source.ParentId = ParentId;
            if (ParentId == -1)
            {
                source.ParentId = null;
            }
            _context.Category.Update(source);
            await _context.SaveChangesAsync();
        }

        /**
        * @brief returns the Id of a category's parent
        * @param TitleDad as the name of the category's parent 
        * @return parentCategory.Id
        */
        public int getParentId(String TitleDad)
        {
            Category parentCategory = _context.Category.Where(c => c.ParentId.Equals(TitleDad)).First();
            return parentCategory.Id;
        }

        /**
        * @brief returns the Id of a category
        * @param Id of a category 
        * @return Category.Id, la llave de la categoría actual
        */
        public Category getCategory(int Id)
        {
            return _context.Category.Find(Id);
        }

        public async Task<IList<Product>> GetProductsByCategoryAsync(string email, int category_id)
        {
            return await _context.Product.Where(product => String.Equals(product.Entrepreneur_Email, email) && product.Category_ID == category_id).ToListAsync();

        }


        public async Task<IList<Category>> getAllCategoryBySupplies(List<Product> product, List<HasSupplies> my_supplies) {

            List<Category> categories = new List<Category>();
            foreach (var prod in product) {
                bool valid_Product = my_supplies.FindAll(c => c.Supplie_ID == prod.Category_ID).Count() > 0;
                if (valid_Product) {
                    var cat = getCategory(prod.Category_ID);
                
                    if (!categories.Contains(cat)) {
                        categories.Add(cat);
                    }
                
                    
                } 

             
            }

            return categories;


        }

        /**
       * @brief Verifies if the selected category is a child
       * @param Id of category
       * @return false if is not child, true if it is
       */
        public bool isChildNode(int Id)
        {
            bool isChild = false;
            if (_context.Category.Where(c => c.ParentId.Equals(Id)).Count() == 0)
            {
                isChild = true;
            }
            return isChild;
        }

        /**
        * @brief Drag and drop a category into another (parent changer)
        * @details RowDragEventArgs references the dragged row (category)
        * @param args selected, to main target
        * @return
        */
        public async void Rowdrop(Syncfusion.Blazor.Grids.RowDragEventArgs<Category> args, SfTreeGrid<Category> main)
        {
            this.TreeGrid = main;
            var position = args.Target.ID;
            if (position == " e-dropchild")
            {
                var CurrentViewData = this.TreeGrid.GetCurrentViewRecords();
                var TargetCategory = CurrentViewData.ElementAt((int)args.DropIndex);
                var SourceCategory = CurrentViewData.ElementAt((int)args.FromIndex);
                await ChangeParent(SourceCategory.Id, TargetCategory.Id);
            }
            else
            {
                if (position == " e-droptop")
                {
                    var CurrentViewData = this.TreeGrid.GetCurrentViewRecords();
                    var SourceCategory = CurrentViewData.ElementAt((int)args.FromIndex);
                    await ChangeParent(SourceCategory.Id, -1);
                }
                else
                {
                    args.Cancel = true;
                }
            }
        }
        public string GetTitleById(int? id)
        {
            string title = "";
            if (id!= null)
            {
                title =_context.Category.Find(id).Title;
            }
            return title;
        }

        /**
         * @brief Get categories that have no parent
         * @param 
         * @return List of parent categories
        **/
        public IList<Category> getParents()
        {
            return _context.Category.FromSqlRaw("SELECT * FROM Category WHERE ParentId IS NULL").ToArray();
        }

        /**
         * @brief Get categories that have a specific parent
         * @param Id of the parent
         * @return List of children of a parent category
        **/
        public IList<Category> getChildrenOf(int parentId)
        {
            return _context.Category.FromSqlRaw("SELECT * FROM Category WHERE ParentId = " + parentId).ToArray();
        }

        public string GetTitle(int id){
            return _context.Category.Find(id).Title;
        }
    }
}
